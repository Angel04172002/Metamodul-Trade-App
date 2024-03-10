using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MetamodulTradeApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClientRequest> ClientRequests { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<UserProduct> UsersProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<Post>()
                .HasMany(e => e.Comments)
                .WithOne(e => e.Post)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<UserProduct>()
                .HasOne(e => e.Product)
                .WithMany(e => e.UsersProducts)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<UserProduct>()
                .HasKey(pk => new { pk.UserId, pk.ProductId });
              

            base.OnModelCreating(builder);
        }
    }
}
