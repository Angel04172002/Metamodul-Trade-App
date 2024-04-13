using MetamodulTradeApp.Infrastructure.Data.Models;

namespace MetamodulTradeApp.Core.Models.Post
{
    public class PostAllViewModel
    {
        public const int PostsPerPage = 6;

        public int CurrentPage { get; set; } = 1;

        public int TotalPostsCount { get; set; }
        
        public string SearchTerm { get; set; } = null!;

        public IEnumerable<PostServiceModel> Posts { get; set; }
          = new List<PostServiceModel>();   
    }
}
