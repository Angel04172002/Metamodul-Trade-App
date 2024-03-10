using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MetamodulTradeApp.Infrastructure.Data.Constants.DataConstants;


namespace MetamodulTradeApp.Infrastructure.Data.Models
{
    [Comment("Product Entity")]
    public class Product
    {
        [Key]
        [Comment("Product Identifier")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(ProductNameMaxLength)]
        [Comment("Product's name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(ProductDescriptionMaxLength)]
        [Comment("Product's description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Product's Price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Product's image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Product's date of creation")]
        public DateTime CreatedOn { get; set; }


        [Required]
        [Comment("Product's Category Identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public ProductCategory Category { get; set; } = null!;

        [Required]
        [Comment("Product's creator Identifier")]
        public string CreatorId { get; set; } = string.Empty;

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;

        public IList<UserProduct> UsersProducts { get; set; } = new List<UserProduct>();
    }
}
