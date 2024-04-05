using MetamodulTradeApp.Core.Models.ClientRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Core.Services.Contracts
{
    public interface IClientRequestService
    {
        Task<IEnumerable<ClientRequestAllViewModel>> GetAllRequestsAsync();
        Task AddRequestAsync(ClientRequestFormViewModel model);

        Task EditRequestAsync(ClientRequestFormViewModel model ,int id);

        Task RemoveRequestAsync(int id);

        Task<IEnumerable<ClientRequestAllViewModel>> GetMyRequestsAsync(string userId);
    }
}
