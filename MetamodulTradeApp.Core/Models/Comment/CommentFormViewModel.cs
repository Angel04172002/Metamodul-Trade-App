using System.ComponentModel.DataAnnotations;
using static MetamodulTradeApp.Core.Constants.ErrorMessages;
using static MetamodulTradeApp.Infrastructure.Data.Constants.DataConstants;

namespace MetamodulTradeApp.Core.Models.Comment
{
    public class CommentFormViewModel
    {

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(
            CommentTextMaxLength,
            MinimumLength = CommentTextMinLength,
            ErrorMessage = StringLengthErrorMessage
            )]
        public string Text { get; set; } = null!;


        public string CreatedOn { get; set; } = null!;


        public string CreatorId { get; set; } = null!;


        public int PostId { get; set; }
    }
}
