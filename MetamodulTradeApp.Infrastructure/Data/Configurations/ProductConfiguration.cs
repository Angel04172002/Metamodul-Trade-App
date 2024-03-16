using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetamodulTradeApp.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(SeedProducts());
        }

        private List<Product> SeedProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Масло",
                    Description = "Моторно масло за двигател",
                    ImageUrl = "https://www.stitchandskein.com/media/2021/08/wheel-oil.jpg",
                    Price = 70,
                    CreatedOn = DateTime.Now.AddMonths(-3),
                    CreatorId = "ece06352-f235-4345-94a7-1a2c12f03ac6",
                    CategoryId = 2
                },
                new Product()
                {
                    Id = 2,
                    Name = "Камион",
                    Description = "Камион за превоз на машини",
                    ImageUrl = "https://www.stitchandskein.com/media/2021/08/wheel-oil.jpg",
                    Price = 15000,
                    CreatedOn = DateTime.Now.AddMonths(-3),
                    CreatorId = "ece06352-f235-4345-94a7-1a2c12f03ac6",
                    CategoryId = 1
                }
            };

            return products;
        }
    }
}
