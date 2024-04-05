using MetamodulTradeApp.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Core.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductServiceModel>> GetAllProductsAsync();
        Task<IEnumerable<ProductServiceModel>> GetMyProductsAsync(string userId);

        Task LikeProductAsync();

        Task UnlikeProductAsync();

        Task AddProductAsync(ProductFormViewModel model);
        Task EditProductAsync(ProductFormViewModel model, int id);
        Task DeleteProductAsync(int id);

    }
}
