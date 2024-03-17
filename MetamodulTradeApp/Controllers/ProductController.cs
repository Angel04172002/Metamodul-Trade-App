using MetamodulTradeApp.Core.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetamodulTradeApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Services()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormViewModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductFormViewModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Remove()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Like()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Unlike()
        {
            return View();
        }
    }
}
