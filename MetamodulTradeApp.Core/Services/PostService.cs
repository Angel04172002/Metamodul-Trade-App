using MetamodulTradeApp.Core.Models.Post;
using MetamodulTradeApp.Core.Services.Contracts;
using MetamodulTradeApp.Data;
using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MetamodulTradeApp.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext context;

        public PostService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddPostAsync(PostFormViewModel model)
        {
            Post post = new Post()
            {
                Title = model.Title,
                CreatedOn = DateTime.Now,
                CreatorId = "",
                Description = model.Description,
                ImageUrl = model.ImageUrl,
            };

            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
        }

        public async Task EditPostAsync(PostFormViewModel model ,int id)
        {
            Post? post = await context.Posts.FindAsync(id);

            if (post != null)
            {
                post.Title = model.Title;
                post.Description = model.Description;
                post.ImageUrl = model.ImageUrl;
                post.CreatedOn = DateTime.Parse(model.CreatedOn);

                await context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<PostAllViewModel>> GetAllPostsAsync()
        {
            return await context.Posts
                .AsNoTracking()
                .Select(p => new PostAllViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    CreatedOn = p.CreatedOn.ToString(),
                    Title = p.Title
                })
                .ToListAsync();
        }

        public async Task RemovePostAsync(int id)
        {
            Post? post = await context.Posts.FindAsync(id);

            if (post != null)
            {
                context.Posts.Remove(post);
                await context.SaveChangesAsync();
            }
    
        }

   
    }
}
