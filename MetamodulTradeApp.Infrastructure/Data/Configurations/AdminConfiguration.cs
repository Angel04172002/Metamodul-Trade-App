using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Infrastructure.Data.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(new IdentityUser[] { SeedAdmin() });
        }

        private IdentityUser SeedAdmin()
        {
            var passwordHasher = new PasswordHasher<IdentityUser>();

            var admin = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8=83d9-d6b3ac1f591e",
                UserName = "angel04172002@gmail.com",
                NormalizedUserName = "ANGEL04172002@GMAIL.COM",
                Email = "angel04172002@gmail.com",
                NormalizedEmail = "ANGEL04172002@GMAIL.COM",
            };

            admin.PasswordHash = passwordHasher.HashPassword(admin, "admin123");

            return admin;
        }
    }
}
