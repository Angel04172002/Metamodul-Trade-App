using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetamodulTradeApp.Controllers
{
    [Authorize]
    public class ObjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Stations()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Gallery()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Compare()
        {
            return View();
        }
    }
}
