using MetamodulTradeApp.Core.Models.ClientRequest;
using MetamodulTradeApp.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Core.Services
{
    public class ClientRequestService : IClientRequestService
    {
        public Task AddRequestAsync(ClientRequestFormViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClientRequestAllViewModel>> GetAllRequestsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClientRequestAllViewModel>> GetMyRequestsAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveRequestAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
