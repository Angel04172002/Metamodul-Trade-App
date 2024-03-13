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
                    Text = "Nice post!",
                    PostId = 1,
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    CreatorId = ""
                },
                new Comment()
                {
                    Id = 1,
                    Text = "Nice post!",
                    PostId = 1,
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    CreatorId = ""
                },
                new Comment()
                {
                    Id = 1,
                    Text = "Nice post!",
                    PostId = 1,
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    CreatorId = ""
                }
            };

            return comments;
        }
    }
}
