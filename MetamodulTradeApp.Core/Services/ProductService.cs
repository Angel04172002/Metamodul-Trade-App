using MetamodulTradeApp.Core.Models.Product;
using MetamodulTradeApp.Core.Services.Contracts;
using MetamodulTradeApp.Data;
using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddProductAsync(ProductFormViewModel model)
        {
            Product product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId,
                CreatedOn = DateTime.Now,
                CreatorId = "",
                ImageUrl = model.ImageUrl
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            Product? product = await context.Products.FindAsync(id);

            if (product == null)
            {
                throw new Exception();
            }


            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task EditProductAsync(ProductFormViewModel model, int id)
        {
            Product? product = await context.Products.FindAsync(id);

            if(product == null) 
            {
                throw new Exception();
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;
            product.ImageUrl = model.ImageUrl;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductAllViewModel>> GetAllProductsAsync()
        {
            return await context.Products
                .AsNoTracking()
                .Select(p => new ProductAllViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    CreatedOn = p.CreatedOn
                })
                .ToListAsync();
        }

        public Task<IEnumerable<ProductAllViewModel>> GetMyProductsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task LikeProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task UnlikeProductAsync()
        {
            throw new NotImplementedException();
        }
    }
}
