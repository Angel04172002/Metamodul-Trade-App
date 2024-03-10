using MetamodulTradeApp.Core.Models.Post;
using MetamodulTradeApp.Core.Services.Contracts;
using MetamodulTradeApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext context;

        public PostService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddPostAsync()
        {
            throw new NotImplementedException();
        }

        public async Task EditPostAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AllPostsViewModel>> GetAllPostsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RemovePostAsync()
        {
            throw new NotImplementedException();
        }
    }
}
