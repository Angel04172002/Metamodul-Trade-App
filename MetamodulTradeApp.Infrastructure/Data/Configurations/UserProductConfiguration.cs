using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetamodulTradeApp.Infrastructure.Data.Configurations
{
    public class UserProductConfiguration : IEntityTypeConfiguration<UserProduct>
    {
        public void Configure(EntityTypeBuilder<UserProduct> builder)
        {
            builder
            .HasOne(e => e.Product)
            .WithMany(e => e.UsersProducts)
            .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasKey(pk => new { pk.UserId, pk.ProductId });

            builder.HasData(SeedUserProducts());
        }

        private List<UserProduct> SeedUserProducts()
        {
            List<UserProduct> userProducts = new List<UserProduct>()
            {
                new UserProduct()
                {
                    UserId = "506cd08d-e8d0-4d5c-9796-949558867648",
                    ProductId = 1
                },
                new UserProduct()
                {
                    UserId = "506cd08d-e8d0-4d5c-9796-949558867648",
                    ProductId = 2
                },

            };

            return userProducts;
        }
    }
}
