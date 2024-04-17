using MetamodulTradeApp.Core.Exceptions;
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
        private readonly ILogger logger;
        public ProductController(
            IProductService _productService,
            ILogger<ProductController> _logger)
        {
            productService = _productService;
            logger = _logger;
        }


        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] ProductAllViewModel model)
        {
            var products = await productService.GetAllProductsAsync(
                model.SearchTerm, 
                ProductAllViewModel.ProductsPerPage,
                model.CurrentPage);

            model.TotalProductsCount = products.TotalProductsCount;
            model.Products = products.Products;

            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Services()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> Mine([FromQuery] ProductAllViewModel model)
        {
            var userId = User.Id();
            var products = await productService.GetMyProductsAsync(
                userId,
                "",
                ProductAllViewModel.ProductsPerPage,
                model.CurrentPage);

            return View(products);
        }


        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
    
            if(await productService.ProductExistsByIdAsync(id) == false)
            {
                return BadRequest();
            }

            var userId = User.Id();

            if(await productService.UserProductExistsAsync(userId, id) == false)
            {
                await productService.LikeProductAsync(userId, id);
            }

            return RedirectToAction(nameof(Mine));
        }


        [HttpPost]
        public async Task<IActionResult> Unlike(int id)
        {
            if (await productService.ProductExistsByIdAsync(id) == false)
            {
                return BadRequest();
            }

            var userId = User.Id();


            try
            {
                await productService.UnlikeProductAsync(userId, id);
            }
            catch(NullEntityModelException neme)
            {
                logger.LogError(neme, "ProductController/Unlike");
            }
          

            return RedirectToAction(nameof(Mine));
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
