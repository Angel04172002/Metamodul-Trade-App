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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(SeedComments());
        }

        private List<Comment> SeedComments()
        {
            List<Comment> comments = new List<Comment>()
            {
                new Comment()
                {
                    Id = 1,
                    Text = "Откъде мога да си купя този продукт?",
                    PostId = 1,
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    CreatorId = "ece06352-f235-4345-94a7-1a2c12f03ac6"
                },
                new Comment()
                {
                    Id = 2,
                    Text = "Оставям ви имейл за връзка",
                    PostId = 1,
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    CreatorId = "ece06352-f235-4345-94a7-1a2c12f03ac6"
                },
                new Comment()
                {
                    Id = 3,
                    Text = "Много хубава статия!",
                    PostId = 3,
                    CreatedOn = DateTime.Now.AddMonths(-3),
                    CreatorId = "506cd08d-e8d0-4d5c-9796-949558867648"
                }
            };

            return comments;
        }
    }
}
