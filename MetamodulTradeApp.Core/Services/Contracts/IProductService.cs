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
        Task<ProductAllViewModel> GetAllProductsAsync(
            string searchTerm = "",
            int itemsPerPage = 0,
            int currentPage = 0);

        Task<ProductAllViewModel> GetMyProductsAsync(string userId);

        Task<ProductFormViewModel?> GetProductByIdAsync(int id);

        Task LikeProductAsync();

        Task UnlikeProductAsync();

        Task AddProductAsync(ProductFormViewModel model);
        Task EditProductAsync(ProductFormViewModel model, int id);
        Task DeleteProductAsync(int id);

        Task<IEnumerable<ProductCategoryViewModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int id);
    }
}
