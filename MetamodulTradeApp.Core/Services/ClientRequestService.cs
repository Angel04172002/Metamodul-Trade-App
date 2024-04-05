using MetamodulTradeApp.Core.Models.ClientRequest;
using MetamodulTradeApp.Core.Services.Contracts;
using MetamodulTradeApp.Data;
using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MetamodulTradeApp.Core.Services
{
    public class ClientRequestService : IClientRequestService
    {
        private readonly ApplicationDbContext context;

        public ClientRequestService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddRequestAsync(ClientRequestFormViewModel model)
        {
            ClientRequest clientRequest = new ClientRequest()
            {
                Message = model.Message,
                PhoneNumber = model.PhoneNumber,
                Topic = model.Topic,
                CreatedOn = DateTime.Now,
                CreatorId = model.CreatorId,
            };

            await context.ClientRequests.AddAsync(clientRequest);
            await context.SaveChangesAsync();
            
        }

        public async Task EditRequestAsync(ClientRequestFormViewModel model, int id)
        {
            var clientRequest = await context.ClientRequests.FindAsync(id);

            if(clientRequest != null)
            {
                clientRequest.Message = model.Message; 
                clientRequest.Topic = model.Topic;
                clientRequest.PhoneNumber = model.PhoneNumber;

                await context.SaveChangesAsync();
            } 
        }

        public async Task<IEnumerable<ClientRequestAllViewModel>> GetAllRequestsAsync()
        {
            return await context.ClientRequests
                .AsNoTracking()
                .Select(c => new ClientRequestAllViewModel()
                {
                    Id = c.Id,
                    Message = c.Message,
                    Topic = c.Topic,
                    CreatedOn = c.CreatedOn.ToString(),
                    CreatorId = c.CreatorId
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ClientRequestAllViewModel>> GetMyRequestsAsync(string userId)
        {
            return await context.ClientRequests
                .AsNoTracking()
                .Where(c => c.CreatorId == userId)
                .Select(c => new ClientRequestAllViewModel()
                {
                    Id = c.Id,
                    Message = c.Message,
                    Topic = c.Topic,
                    CreatedOn = c.CreatedOn.ToString(),
                    CreatorId = c.CreatorId
                })
                .OrderByDescending(c => DateTime.Parse(c.CreatedOn))
                .ToListAsync();
        }

        public async Task RemoveRequestAsync(int id)
        {
            var clientRequest = await context.ClientRequests.FindAsync(id);

            if(clientRequest != null)
            {
                context.ClientRequests.Remove(clientRequest);
                await context.SaveChangesAsync();
            }
        }
    }
}
