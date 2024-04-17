using MetamodulTradeApp.Core.Models.ClientRequest;
using MetamodulTradeApp.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MetamodulTradeApp.Areas.Admin.Controllers
{
    public class ClientRequestController : Controller
    {
        private readonly IClientRequestService clientRequestService;

        public ClientRequestController(
            IClientRequestService _clientRequestService)
        {
            clientRequestService = _clientRequestService;
        }


        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] ClientRequestAllViewModel model)
        {
            var requests = await clientRequestService.GetAllRequestsAsync(
                    model.CurrentPage,
                   ClientRequestAllViewModel.ClientRequestsPerPage
                );


            return View(requests);
        }
    }
}
