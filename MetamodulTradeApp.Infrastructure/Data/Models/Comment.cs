using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MetamodulTradeApp.Infrastructure.Data.Constants.DataConstants;

namespace MetamodulTradeApp.Infrastructure.Data.Models
{
    [Comment("Comment Entity")]
    public class Comment
    {
        [Key]
        [Comment("Comment Identifier")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(CommentTextMaxLength)]
        [Comment("Comment Text")]
        public string Text { get; set; } = string.Empty;

        [Required]
        [Comment("Comment date of creation")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("Comment's creator Identifier")]
        public string CreatorId { get; set; } = string.Empty;

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;

        [Required]
        [Comment("Comment's post")]
        public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; } = null!;
    }
}
