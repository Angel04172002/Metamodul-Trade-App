using MetamodulTradeApp.Core.Models.Product;
using MetamodulTradeApp.Core.Services.Contracts;
using MetamodulTradeApp.Data;
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

        public Task AddProductAsync(ProductFormViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task EditProductAsync(ProductFormViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductAllViewModel>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
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
