using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetamodulTradeApp.Infrastructure.Data.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(SeedProductCategories());
        }

        private List<ProductCategory> SeedProductCategories()
        {
            List<ProductCategory> productCategories = new List<ProductCategory>()
            {
                new ProductCategory()
                {
                    Id = 1,
                    Name = "Камиони"
                },
                new ProductCategory()
                {
                    Id = 2,
                    Name = "Масла"
                }
            };

            return productCategories;
        }
    }
}
