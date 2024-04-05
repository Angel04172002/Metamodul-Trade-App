namespace MetamodulTradeApp.Core.Models.Product
{
    public class ProductServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public string CreatedOn { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public ICollection<ProductCategoryViewModel> Categories { get; set; }
          = new List<ProductCategoryViewModel>();
    }
}
