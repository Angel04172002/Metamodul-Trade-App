using MetamodulTradeApp.Core.Models.Product;
using MetamodulTradeApp.Core.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetamodulTradeApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }


        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] ProductAllViewModel model)
        {
            var products = await productService.GetAllProductsAsync("", ProductAllViewModel.ProductsPerPage, model.CurrentPage);


            return View(products);
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
            var model = new ProductFormViewModel();
            model.Categories = await productService.AllCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormViewModel model)
        {
            if(await productService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }

            if(ModelState.IsValid == false)
            {
                model.Categories = await productService.AllCategoriesAsync();
                return View(model);
            }

            await productService.AddProductAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await productService.GetProductByIdAsync(id);

            if(product == null)
            {
                return BadRequest();
            }


            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductFormViewModel model)
        {
            var product = await productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return BadRequest();
            }


            if(ModelState.IsValid == false)
            {
                model.Categories = await productService.AllCategoriesAsync();
                return View(model);
            }


            await productService.EditProductAsync(model, id);


            return RedirectToAction(nameof(Index));
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
