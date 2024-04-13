using MetamodulTradeApp.Core.Exceptions;
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
            else
            {
                throw new NullEntityModelException("Product entity model is null!");
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
            else
            {
                throw new NullEntityModelException("Product entity model is null!");
            }

        }

        public async Task<ProductAllViewModel> GetAllProductsAsync(
            string searchTerm = "",
            int itemsPerPage = 0,
            int currentPage = 0
            )
        {

            var products = context.Products
                .AsNoTracking()
                .Select(p => new ProductServiceModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    CreatedOn = p.CreatedOn.ToString(),
                    Category = p.Category.Name,
                    Price = p.Price,
                    Name = p.Name,
                    Creator = p.Creator.UserName,
                });


            var filteredProducts = await GetAllFilteredProductsAsync(searchTerm, currentPage, itemsPerPage, products);


            return new ProductAllViewModel()
            {
                Products = filteredProducts == null ? products : filteredProducts,
                CurrentPage = currentPage,
                TotalProductsCount = products.Count()
            };



        }


        public async Task<ProductDetailsViewModel?> GetDetailsAsync(int id)
        {
            return await context.Products
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsViewModel()
                {
                    Id = p.Id,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    CreatedOn = p.CreatedOn.ToString(),
                    Name = p.Name,
                    Creator = p.Creator.UserName,
                    Category = p.Category.Name,
                    Price = p.Price
                })
                .FirstOrDefaultAsync();

        }



        public async Task<ProductAllViewModel> GetMyProductsAsync(
            string? userId, 
            string searchTerm = "", 
            int itemsPerPage = 0, 
            int currentPage = 0)
        {


            var userProducts = context.UsersProducts
                .Where(up => up.UserId == userId)
                .Select(up => new ProductServiceModel()
                {
                    Id = up.ProductId,
                    ImageUrl = up.Product.ImageUrl,
                    CreatedOn = up.Product.CreatedOn.ToString(),
                    Category = up.Product.Category.Name,
                    Price = up.Product.Price,
                    Name = up.Product.Name,
                    Creator = up.Product.Creator.UserName,
                });

            var filteredProducts = await GetAllFilteredProductsAsync("", currentPage, itemsPerPage, userProducts);

            return new ProductAllViewModel()
            {
                Products = filteredProducts,
                CurrentPage = currentPage,
                TotalProductsCount = userProducts.Count()
            };
        }

        public async Task<ProductDetailsViewModel?> GetProductByIdAsync(int id)
        {
            return await context.Products
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsViewModel()
                {
                    Id = p.Id,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Price = p.Price,
                    CreatedOn = p.CreatedOn.ToString(),
                    Category = p.Category.Name,
                    Creator = p.Creator.UserName,

                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetProductCategoryIdAsync(int id)
        {
            return await context.Products
                .Where(p => p.Id == id)
                .Select(p => p.Category.Id)
                .FirstOrDefaultAsync();     
        }

        public async Task LikeProductAsync(string? userId, int productId)
        {
            var userProduct = await context.UsersProducts
                .FirstOrDefaultAsync(up => up.UserId == userId && up.ProductId == productId);

            if (userProduct == null)
            {
                context.UsersProducts.Add(new UserProduct()
                {
                    UserId = userId,
                    ProductId = productId
                });

                await context.SaveChangesAsync();
            }

        }

        public Task UnlikeProductAsync()
        {
            throw new NotImplementedException();
        }


        private async Task<List<ProductServiceModel>?> GetAllFilteredProductsAsync(
            string? searchTerm, 
            int currentPage, 
            int itemsPerPage,
            IQueryable<ProductServiceModel> products)
        {
            var normalisedSearchTerm = searchTerm?.ToLower();
            List<ProductServiceModel>? filteredProducts = null;

            if (normalisedSearchTerm != null)
            {

                filteredProducts = await products
                      .Where(p => p.Name.ToLower().Contains(normalisedSearchTerm) ||
                                  p.Category.ToLower().Contains(normalisedSearchTerm))
                      .Skip((currentPage - 1) * itemsPerPage)
                      .Take(itemsPerPage)
                      .ToListAsync();
            }

  

            return filteredProducts;
        }
    }
}
