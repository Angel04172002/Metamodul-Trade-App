using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Name = "Oil",
                    Description = "Oil for spinning wheel",
                    ImageUrl = "https://www.stitchandskein.com/media/2021/08/wheel-oil.jpg",
                    Price = 30,
                    CreatedOn = DateTime.Now.AddMonths(-3),
                    CreatorId = ""
                },
                new Product()
                {
                    Id = 1,
                    Name = "Oil",
                    Description = "Oil for spinning wheel",
                    ImageUrl = "https://www.stitchandskein.com/media/2021/08/wheel-oil.jpg",
                    Price = 30,
                    CreatedOn = DateTime.Now.AddMonths(-3),
                    CreatorId = ""
                },
                new Product()
                {
                    Id = 1,
                    Name = "Oil",
                    Description = "Oil for spinning wheel",
                    ImageUrl = "https://www.stitchandskein.com/media/2021/08/wheel-oil.jpg",
                    Price = 30,
                    CreatedOn = DateTime.Now.AddMonths(-3),
                    CreatorId = ""
                },
            };

            return products;
        }
    }
}
