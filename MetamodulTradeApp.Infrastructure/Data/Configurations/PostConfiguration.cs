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
                    Title = "Пост за камиони",
                    Description = "Описание на пост 1 за камиони",
                    CreatedOn = DateTime.Now.AddMonths(-10),
                    ImageUrl = "https://i.stack.imgur.com/GsDIl.jpg",
                    CreatorId = "ece06352-f235-4345-94a7-1a2c12f03ac6"
                },
                new Post()
                {
                    Id = 2,
                    Title = "Пост за природен газ",
                    Description = "Описание на пост 2 за природен газ",
                    CreatedOn = DateTime.Now.AddMonths(-4),
                    ImageUrl = "https://i.stack.imgur.com/GsDIl.jpg",
                    CreatorId = "ece06352-f235-4345-94a7-1a2c12f03ac6"
                },
                new Post()
                {
                    Id = 3,
                    Title = "Пост за масла",
                    Description = "Описание на пост 3 за масла",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    ImageUrl = "https://i.stack.imgur.com/GsDIl.jpg",
                    CreatorId = "ece06352-f235-4345-94a7-1a2c12f03ac6"
                },
            };

            return posts;

        }
    }
}
