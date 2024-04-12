using MetamodulTradeApp.Core.Models.Post;
using MetamodulTradeApp.Core.Models.Product;
using MetamodulTradeApp.Core.Services;
using MetamodulTradeApp.Core.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var products = await productService.GetAllProductsAsync(
                model.SearchTerm, 
                ProductAllViewModel.ProductsPerPage,
                model.CurrentPage);


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


            model.CreatorId = User.Id();

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

            var categoryId = await productService.GetProductCategoryIdAsync(id);

            var model = new ProductFormViewModel()
            {
                ImageUrl = product.ImageUrl,
                CategoryId = categoryId,
                CreatedOn = product.CreatedOn,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
            };

            model.Categories = await productService.AllCategoriesAsync();

            return View(model);
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
        public async Task<IActionResult> Delete(int id)
        {

            var product = await productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            var model = new ProductDeleteFormViewModel()
            {
                Id = product.Id,
                CreatedOn = DateTime.Parse(product.CreatedOn),
                Title = product.Name,
                Price = product.Price
            };

            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            await productService.DeleteProductAsync(id);


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Mine([FromQuery] ProductAllViewModel model)
        {
            var userId = User.Id();
            var products = await productService.GetMyProductsAsync(userId);

            return View(products);
        }


        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            var userId = User.Id();

            await productService.LikeProductAsync(userId, id);

            return RedirectToAction(nameof(Mine));
        }


        [HttpPost]
        public async Task<IActionResult> Unlike()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await productService.GetDetailsAsync(id);

            if (productDetails == null)
            {
                return BadRequest();
            }


            return View(productDetails);
        }
    }
}
