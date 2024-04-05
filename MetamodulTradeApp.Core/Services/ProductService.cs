using MetamodulTradeApp.Core.Models.Post;
using MetamodulTradeApp.Core.Models.Product;
using MetamodulTradeApp.Core.Services.Contracts;
using MetamodulTradeApp.Data;
using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

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
                CreatorId = model.CreatorId,
                ImageUrl = model.ImageUrl
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductCategoryViewModel>> AllCategoriesAsync()
        {
            return await context.ProductCategories
                .AsNoTracking()
                .Select(pc => new ProductCategoryViewModel()
                {
                    Id = pc.Id,
                    Name = pc.Name
                })
                .ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int id)
        {
            return await context.ProductCategories
                .AnyAsync(pc =>  pc.Id == id);
        }

        public async Task DeleteProductAsync(int id)
        {
            Product? product = await context.Products.FindAsync(id);

            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }

        }

        public async Task EditProductAsync(ProductFormViewModel model, int id)
        {
            Product? product = await context.Products.FindAsync(id);

            if(product != null) 
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.CategoryId = model.CategoryId;
                product.ImageUrl = model.ImageUrl;

                await context.SaveChangesAsync();
            }

        }

        public async Task<ProductAllViewModel> GetAllProductsAsync(
            string searchTerm = "",
            int itemsPerPage = 0,
            int currentPage = 0
            )
        {

            var products = await context.Products
               .AsNoTracking()
               .Skip((currentPage - 1) * itemsPerPage)
               .Take(itemsPerPage)
               .Select(p => new ProductServiceModel()
               {
                   Id = p.Id,
                   ImageUrl = p.ImageUrl,
                   CreatedOn = p.CreatedOn.ToString(),
                   Category = p.Category.Name,
                   Price = p.Price,
                   Name = p.Name
               })
               .ToListAsync();


            return new ProductAllViewModel()
            {
                Products = products,
                CurrentPage = currentPage,
                TotalProductsCount = products.Count()
            };



        }

        public async Task<ProductAllViewModel> GetMyProductsAsync(string userId)
        {

            throw new NotImplementedException();
        }

        public async Task<ProductFormViewModel?> GetProductByIdAsync(int id)
        {
            return await context.Products
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new ProductFormViewModel()
                {
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    CreatedOn = p.CreatedOn.ToString(),
                    CreatorId = p.CreatorId
                })
                .FirstOrDefaultAsync();
        }

        public async Task LikeProductAsync()
        {
            //context.UsersProducts.Add(new UserProduct()
            //{
            //    UserId = userId,
            //    ProductId = 
            //});
        }

        public Task UnlikeProductAsync()
        {
            throw new NotImplementedException();
        }
    }
}
