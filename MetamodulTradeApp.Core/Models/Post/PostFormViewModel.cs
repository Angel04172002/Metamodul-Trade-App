using System.ComponentModel.DataAnnotations;
using static MetamodulTradeApp.Core.Constants.ErrorMessages;
using static MetamodulTradeApp.Infrastructure.Data.Constants.DataConstants;

namespace MetamodulTradeApp.Core.Models.Post
{
    public class PostFormViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(
            PostTitleMaxLength,
            MinimumLength = PostTitleMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = string.Empty;


        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(
            PostDescriptionMaxLength,
            MinimumLength = PostDescriptionMinLength,
            ErrorMessage = StringLengthErrorMessage
            )]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public string ImageUrl { get; set; } = string.Empty;


        public string? CreatedOn { get; set; } 

        public string? CreatorId { get; set; }
    }
}
