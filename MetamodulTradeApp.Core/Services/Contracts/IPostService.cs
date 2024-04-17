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
        Task<PostAllViewModel> GetAllPostsAsync(
            string searchTerm,
            int itemsPerPage,
            int currentPage);


        Task<PostDetailsViewModel?> GetPostByIdAsync(int id);

        Task AddPostAsync(PostFormViewModel model);

        Task EditPostAsync(PostFormViewModel model, int id);

        Task RemovePostAsync(int id);

        Task<PostDetailsViewModel?> GetDetailsAsync(int id);
    }
}
