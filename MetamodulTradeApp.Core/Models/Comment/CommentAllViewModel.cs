﻿namespace MetamodulTradeApp.Core.Models.Comment
{
    public class CommentAllViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; } = string.Empty;


        public string CreatedOn { get; set; } = null!;


        public string Creator { get; set; } = string.Empty;

        public string CreatorId { get; set; } = string.Empty;


        public int PostId { get; set; }

    }
}
