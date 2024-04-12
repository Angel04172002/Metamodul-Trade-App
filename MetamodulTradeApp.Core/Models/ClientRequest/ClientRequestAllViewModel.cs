using MetamodulTradeApp.Core.Models.Post;

namespace MetamodulTradeApp.Core.Models.ClientRequest
{
    public class ClientRequestAllViewModel
    {

        public const int ClientRequestsPerPage = 6;

        public int CurrentPage { get; set; } = 1;

        public int TotalRequestsCount { get; set; }


        public IEnumerable<ClientRequestServiceModel> ClientRequests { get; set; }
          = new List<ClientRequestServiceModel>();


    }
}
