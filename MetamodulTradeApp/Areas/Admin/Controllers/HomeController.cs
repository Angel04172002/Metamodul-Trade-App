using Microsoft.AspNetCore.Mvc;

namespace MetamodulTradeApp.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {

        public IActionResult DashBoard()
        {
            return View();
        }
   
    }
}
