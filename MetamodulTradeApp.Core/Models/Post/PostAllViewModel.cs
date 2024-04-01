using MetamodulTradeApp.Infrastructure.Data.Models;

namespace MetamodulTradeApp.Core.Models.Post
{
    public class PostAllViewModel
    {

        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string CreatedOn { get; set; } = null!;

    }
}
