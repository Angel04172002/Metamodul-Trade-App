using System.ComponentModel.DataAnnotations;
using static MetamodulTradeApp.Core.Constants.ErrorMessages;
using static MetamodulTradeApp.Infrastructure.Data.Constants.DataConstants;


namespace MetamodulTradeApp.Core.Models.ClientRequest
{
    public class ClientRequestFormViewModel
    {

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(
            ClientRequestPhoneNumberMaxLength,
            MinimumLength = ClientRequestPhoneNumberMinLength,
            ErrorMessage = StringLengthErrorMessage
            )]
        public string PhoneNumber { get; set; } = null!;


        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(
            ClientRequestTopicMaxLength,
            MinimumLength = ClientRequestTopicMinLength,
            ErrorMessage = StringLengthErrorMessage
            )]
        public string Topic { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(
            ClientRequestMessageMaxLength,
            MinimumLength = ClientRequestMessageMinLength,
            ErrorMessage = StringLengthErrorMessage
            )]
        public string Message { get; set; } = null!;

        public string? CreatedOn { get; set; }

        public string? CreatorId { get; set; }
    }
}
