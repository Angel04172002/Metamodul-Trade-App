﻿using MetamodulTradeApp.Core.Models.Product;
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

        Task<ProductAllViewModel> GetMyProductsAsync(
            string? userId,
            string searchTerm = "",
            int itemsPerPage = 0,
            int currentPage = 0);

        Task<ProductDetailsViewModel?> GetProductByIdAsync(int id);

        Task LikeProductAsync(string userId, int productId);

        Task UnlikeProductAsync(string userId, int productId);

        Task AddProductAsync(ProductFormViewModel model);
        Task EditProductAsync(ProductFormViewModel model, int id);
        Task DeleteProductAsync(int id);


        Task<ProductDetailsViewModel?> GetDetailsAsync(int id);

        Task<IEnumerable<ProductCategoryViewModel>> AllCategoriesAsync();

        Task<int> GetProductCategoryIdAsync(int id);

        Task<bool> CategoryExistsAsync(int id);

        Task<bool> ProductExistsByIdAsync(int id);

        Task<bool> UserProductExistsAsync(string userId, int productId);
    }
}
