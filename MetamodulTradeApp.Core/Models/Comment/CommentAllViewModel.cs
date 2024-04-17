using MetamodulTradeApp.Core.Models.Post;

namespace MetamodulTradeApp.Core.Models.Comment
{
    public class CommentAllViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; } = string.Empty;


        public string CreatedOn { get; set; } = string.Empty;


        public string Creator { get; set; } = string.Empty;

        public string CreatorId { get; set; } = string.Empty;


        public int PostId { get; set; }

        public PostServiceModel Post { get; set; } = null!;

    }
}
