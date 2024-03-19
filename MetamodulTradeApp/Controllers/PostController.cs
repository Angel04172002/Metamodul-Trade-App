using MetamodulTradeApp.Core.Models.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetamodulTradeApp.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        //Return view with all posts
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous] 
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormViewModel model)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]   
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostFormViewModel model, int id)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Remove()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
