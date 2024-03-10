using MetamodulTradeApp.Core.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Core.Services.Contracts
{
    public interface IPostService
    {
        Task<IEnumerable<AllPostsViewModel>> GetAllPostsAsync();

        Task AddPostAsync();

        Task EditPostAsync();

        Task RemovePostAsync();
    }
}
