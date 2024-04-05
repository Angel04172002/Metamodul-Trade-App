namespace MetamodulTradeApp.Core.Models.Product
{
    public class ProductAllViewModel
    {
        public const int ProductsPerPage = 6;

        public int CurrentPage { get; set; } = 1;

        public int TotalProductsCount { get; set; }

        public IEnumerable<ProductServiceModel> Products { get; set; }
            = new List<ProductServiceModel>();
    }
}
