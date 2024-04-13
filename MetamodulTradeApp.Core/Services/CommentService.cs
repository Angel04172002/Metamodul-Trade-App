using MetamodulTradeApp.Core.Exceptions;
using MetamodulTradeApp.Core.Models.Comment;
using MetamodulTradeApp.Core.Services.Contracts;
using MetamodulTradeApp.Data;
using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext context;

        public CommentService(ApplicationDbContext _context)
        {
            context = _context;   
        }

        public async Task AddCommentAsync(CommentFormViewModel model)
        {
            var comment = new Comment()
            {
                PostId = model.PostId,
                Text = model.Text,
                CreatorId = model.CreatorId,
                CreatedOn = DateTime.Now
            };

            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await context.Comments.FindAsync(id);

            if(comment != null)
            {
                context.Comments.Remove(comment);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new NullEntityModelException("Comment entity model is null!");
            }
        }

        public async Task EditCommentAsync(int id, CommentFormViewModel model)
        {
            var comment = await context.Comments.FindAsync(id);

            if(comment != null) 
            {
                comment.Text = model.Text;
                await context.SaveChangesAsync();
            }
            else
            {
                throw new NullEntityModelException("Comment entity model is null!");
            }

        }

        public async Task<CommentAllViewModel?> GetCommentByIdAsync(int id)
        {
            return await context.Comments
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CommentAllViewModel()
                {
                    Id = c.Id,
                    PostId = c.PostId,
                    Text = c.Text,
                    CreatedOn = c.CreatedOn.ToString(),
                    CreatorId = c.CreatorId,
                    Creator = c.Creator.UserName
                })
                .FirstOrDefaultAsync();
        }
    }
}
