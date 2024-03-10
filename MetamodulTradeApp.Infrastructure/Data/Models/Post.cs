using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static MetamodulTradeApp.Infrastructure.Data.Constants.DataConstants;



namespace MetamodulTradeApp.Infrastructure.Data.Models
{
    [Comment("Post Entity")]
    public class Post
    {
        [Key]
        [Comment("Post Identifier")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(PostTitleMaxLength)]
        [Comment("Post Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(PostDescriptionMaxLength)]
        [Comment("Post Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Post's image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Post date of creation")]
        public DateTime CreatedOn { get; set; }


        [Required]
        [Comment("Post's creator Identifier")]
        public string CreatorId { get; set; } = string.Empty;

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;

        public IList<Comment> Comments { get; set; } = new List<Comment>();
    }
}
