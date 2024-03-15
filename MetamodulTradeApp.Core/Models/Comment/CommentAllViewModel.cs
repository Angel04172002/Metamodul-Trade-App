namespace MetamodulTradeApp.Core.Models.Comment
{
    public class CommentAllViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; } = string.Empty;


        public DateTime CreatedOn { get; set; }

    
        public string CreatorId { get; set; } = string.Empty;


        public int PostId { get; set; }

    }
}
