using MetamodulTradeApp.Core.Models.Comment;

namespace MetamodulTradeApp.Core.Models.Post
{
    public class PostDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public ICollection<CommentAllViewModel> Comments { get; set; }
           = new List<CommentAllViewModel>();
    }
}
