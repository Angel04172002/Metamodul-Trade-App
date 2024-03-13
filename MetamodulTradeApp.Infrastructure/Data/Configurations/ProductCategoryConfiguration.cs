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
                    Name = ""
                },
                new ProductCategory()
                {
                    Id = 1,
                    Name = ""
                },
                new ProductCategory()
                {
                    Id = 1,
                    Name = ""
                },
            };

            return productCategories;
        }
    }
}
