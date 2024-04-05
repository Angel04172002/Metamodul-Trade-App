using MetamodulTradeApp.Core.Models.Comment;

namespace MetamodulTradeApp.Core.Models.Post
{
    public class PostDetailsViewModel : PostServiceModel
    {

        public string Description { get; set; } = string.Empty;

        public ICollection<CommentAllViewModel> Comments { get; set; }
           = new List<CommentAllViewModel>();
    }
}
