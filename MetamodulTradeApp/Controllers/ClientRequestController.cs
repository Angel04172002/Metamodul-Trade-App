using MetamodulTradeApp.Core.Models.ClientRequest;
using MetamodulTradeApp.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MetamodulTradeApp.Controllers
{
    public class ClientRequestController : Controller
    {
        private readonly IClientRequestService clientRequestService;

        public ClientRequestController(IClientRequestService _clientRequestService)
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

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ClientRequestFormViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClientRequestFormViewModel model)
        {
            
            if(ModelState.IsValid == false)
            {
                return View(model);
            }


            model.CreatorId = User.Id();

            await clientRequestService.AddRequestAsync(model);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var clientRequest = await clientRequestService.GetRequestByIdAsync(id);

            if(clientRequest == null)
            {
                return BadRequest();
            }

            if(clientRequest.CreatorId != User.Id())
            {
                return Unauthorized();
            }

            var model = new ClientRequestFormViewModel()
            {
                Message = clientRequest.Message,
                Topic = clientRequest.Topic,
                PhoneNumber = clientRequest.PhoneNumber
            };
            
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, ClientRequestFormViewModel model)
        {

            var clientRequest = await clientRequestService.GetRequestByIdAsync(id);

            if (clientRequest == null)
            {
                return BadRequest();
            }

            if (clientRequest.CreatorId != User.Id())
            {
                return Unauthorized();
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await clientRequestService.EditRequestAsync(model, id);

            return RedirectToAction(nameof(Index)); 
        }
    }
}
