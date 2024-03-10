using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using static MetamodulTradeApp.Infrastructure.Data.Constants.DataConstants;

namespace MetamodulTradeApp.Infrastructure.Data.Models
{
    [Comment("Product Category Entity")]
    public class ProductCategory
    {
        [Key]
        [Comment("Product Category Identifier")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(ProductCategoryMaxLength)]
        [Comment("Product Category's name")]
        public string Name { get; set; } = string.Empty;

        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
