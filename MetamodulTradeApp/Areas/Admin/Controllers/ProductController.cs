﻿using MetamodulTradeApp.Core.Exceptions;
using MetamodulTradeApp.Core.Models.Product;
using MetamodulTradeApp.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace MetamodulTradeApp.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
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
        public async Task<IActionResult> Add()
        {
            var model = new ProductFormViewModel();
            model.Categories = await productService.AllCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormViewModel model)
        {
            if (await productService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }

            if (ModelState.IsValid == false)
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

            if (product == null)
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


            if (ModelState.IsValid == false)
            {
                model.Categories = await productService.AllCategoriesAsync();
                return View(model);
            }

            try
            {

                await productService.EditProductAsync(model, id);
            }
            catch (NullEntityModelException neme)
            {
                logger.LogError(neme, "ProductController/Edit");
                return BadRequest();
            }


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

            try
            {
                await productService.DeleteProductAsync(id);
            }
            catch (NullEntityModelException neme)
            {
                logger.LogError(neme, "ProductController/DeleteConfirmed");
                return BadRequest();
            }


            return RedirectToAction(nameof(Index));
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
