using MetamodulTradeApp.Core.Models.Comment;

namespace MetamodulTradeApp.Core.Models.Post
{
    public class PostDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string CreatedOn { get; set; } = string.Empty;

        public ICollection<CommentAllViewModel> Comments { get; set; }
           = new List<CommentAllViewModel>();
    }
}
