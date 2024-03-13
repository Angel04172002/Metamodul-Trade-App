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
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(SeedPosts());
        }

        private List<Post> SeedPosts()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "My First Post",
                    Description = "Test Description",
                    CreatedOn = DateTime.Now.AddMonths(-10),
                    ImageUrl = "https://i.stack.imgur.com/GsDIl.jpg",
                    CreatorId = ""
                },
                new Post()
                {
                    Id = 1,
                    Title = "My First Post",
                    Description = "Test Description",
                    CreatedOn = DateTime.Now.AddMonths(-10),
                    ImageUrl = "https://i.stack.imgur.com/GsDIl.jpg",
                    CreatorId = ""
                },
                new Post()
                {
                    Id = 1,
                    Title = "My First Post",
                    Description = "Test Description",
                    CreatedOn = DateTime.Now.AddMonths(-10),
                    ImageUrl = "https://i.stack.imgur.com/GsDIl.jpg",
                    CreatorId = ""
                },
            };

            return posts;

        }
    }
}
