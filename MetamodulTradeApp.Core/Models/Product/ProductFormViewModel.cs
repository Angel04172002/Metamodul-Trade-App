using System.ComponentModel.DataAnnotations;
using static MetamodulTradeApp.Core.Constants.ErrorMessages;
using static MetamodulTradeApp.Infrastructure.Data.Constants.DataConstants;

namespace MetamodulTradeApp.Core.Models.Product
{
    public class ProductFormViewModel
    {

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(
            ProductNameMaxLength,
            MinimumLength = ProductNameMinLength,
            ErrorMessage = StringLengthErrorMessage
            )]
        public string Name { get; set; } = string.Empty;



        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(
            ProductDescriptionMaxLength,
            MinimumLength = ProductDescriptionMinLength,
            ErrorMessage = StringLengthErrorMessage
            )]
        public string Description { get; set; } = string.Empty;


        [Required(ErrorMessage = RequireErrorMessage)]
        public decimal Price { get; set; }


        [Required(ErrorMessage = RequireErrorMessage)]
        public string ImageUrl { get; set; } = string.Empty;

        public string CreatedOn { get; set; } = string.Empty;

        public string CreatorId { get; set; } = string.Empty;


        [Required(ErrorMessage = RequireErrorMessage)]
        public int CategoryId { get; set; }

        public IList<ProductCategoryViewModel> Categories { get; set; }
            = new List<ProductCategoryViewModel>(); 

    }
}
