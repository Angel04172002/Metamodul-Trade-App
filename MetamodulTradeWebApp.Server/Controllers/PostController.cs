using Microsoft.AspNetCore.Mvc;

namespace MetamodulTradeWebApp.Server.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
