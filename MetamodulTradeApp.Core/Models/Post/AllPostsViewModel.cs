using MetamodulTradeApp.Infrastructure.Data.Models;

namespace MetamodulTradeApp.Core.Models.Post
{
    public class AllPostsViewModel
    {

        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; } = string.Empty;
    }
}
