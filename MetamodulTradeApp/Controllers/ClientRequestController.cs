using MetamodulTradeApp.Core.Models.ClientRequest;
using Microsoft.AspNetCore.Mvc;

namespace MetamodulTradeApp.Controllers
{
    public class ClientRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Add(ClientRequestFormViewModel model)
        {
            return View();
        }
    }
}
