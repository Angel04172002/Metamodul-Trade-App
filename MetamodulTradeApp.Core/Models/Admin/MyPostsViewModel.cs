using MetamodulTradeApp.Core.Models.Post;

namespace MetamodulTradeApp.Core.Models.Admin
{
    public class MyPostsViewModel
    {
        public IEnumerable<PostServiceModel> Posts { get; set; }
         = new List<PostServiceModel>();
    }
}
