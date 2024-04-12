using MetamodulTradeApp.Core.Models.ClientRequest;
using MetamodulTradeApp.Core.Models.Post;
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

        public async Task<ClientRequestAllViewModel> GetAllRequestsAsync(
            int currentPage,
            int requestsPerPage
            )
        {
            var requests = context.ClientRequests
                .AsNoTracking()
                .Select(c => new ClientRequestServiceModel()
                {
                    Id = c.Id,
                    Message = c.Message,
                    Topic = c.Topic,
                    CreatedOn = c.CreatedOn.ToString(),
                    Creator = c.Creator.UserName,
                    CreatorId = cr.Creator.Id
                });

            var filteredRequests = await GetAllFilteredRequestsAsync(currentPage, requestsPerPage, requests);

            return new ClientRequestAllViewModel()
            {
                ClientRequests = filteredRequests,
                CurrentPage = currentPage,
                TotalRequestsCount = filteredRequests.Count()
            };
        }

        public async Task<ClientRequestAllViewModel> GetMyRequestsAsync(
            string userId,
            int currentPage,
            int requestsPerPage
            )
        {
            var requests = context.ClientRequests
                .AsNoTracking()
                .Where(c => c.CreatorId == userId)
                .Select(c => new ClientRequestServiceModel()
                {
                    Id = c.Id,
                    Message = c.Message,
                    Topic = c.Topic,
                    CreatedOn = c.CreatedOn.ToString(),
                    Creator = c.Creator.UserName,
                    CreatorId = cr.Creator.Id
                })
                .OrderByDescending(c => DateTime.Parse(c.CreatedOn));


            var filteredRequests = await GetAllFilteredRequestsAsync(currentPage, requestsPerPage, requests);

            return new ClientRequestAllViewModel()
            {
                ClientRequests = filteredRequests,
                CurrentPage = currentPage,
                TotalRequestsCount = filteredRequests.Count()
            };
        }

        public async Task<ClientRequestServiceModel?> GetRequestByIdAsync(int id)
        {
            return await context.ClientRequests
                .AsNoTracking()
                .Where(cr => cr.Id == id)
                .Select(cr => new ClientRequestServiceModel()
                {
                    Id = cr.Id,
                    Message = cr.Message,
                    Topic = cr.Topic,
                    CreatedOn = cr.CreatedOn.ToString(),
                    Creator = cr.Creator.UserName,
                    CreatorId = cr.Creator.Id
                })
                .FirstOrDefaultAsync();
               
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

        private async Task<List<ClientRequestServiceModel>> GetAllFilteredRequestsAsync(
         int currentPage,
         int itemsPerPage,
         IQueryable<ClientRequestServiceModel> requests)
        {

            List<ClientRequestServiceModel> filteredRequests = await requests
                 .Skip((currentPage - 1) * itemsPerPage)
                 .Take(itemsPerPage)
                 .ToListAsync();

            return filteredRequests;
        }

    }
}
