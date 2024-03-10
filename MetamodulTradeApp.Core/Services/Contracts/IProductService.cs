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
        Task<IEnumerable<AllProductsViewModel>> GetAllProductsAsync();
        Task<IEnumerable<AllProductsViewModel>> GetMyProductsAsync(string userId);

        Task LikeProductAsync();

        Task UnlikeProductAsync();

        Task AddProductAsync(ProductFormViewModel model);
        Task EditProductAsync(ProductFormViewModel model);
        Task DeleteProductAsync();

    }
}
