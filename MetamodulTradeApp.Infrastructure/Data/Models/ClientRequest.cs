using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using static MetamodulTradeApp.Infrastructure.Data.Constants.DataConstants;

namespace MetamodulTradeApp.Infrastructure.Data.Models
{
    [Comment("Client Request Entity")]
    public class ClientRequest
    {
        [Key]
        [Comment("Client Request Identifier")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(ClientRequestTopicMaxLength)]
        [Comment("Client's topic")]
        public string Topic { get; set; } = string.Empty;

        [Required]
        [MaxLength(ClientRequestPhoneNumberMaxLength)]
        [Comment("Client's phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(ClientRequestMessageMaxLength)]
        [Comment("Client's message")]
        public string Message { get; set; } = string.Empty;

        [Required]
        [Comment("Client request's date of creation")]
        public DateTime CreatedOn { get; set; }

        [AllowNull]
        [Comment("Client Request's creator Identifier")]
        public string? CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;
    }
}
