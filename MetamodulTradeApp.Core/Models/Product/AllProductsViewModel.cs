using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Core.Models.Product
{
    public class AllProductsViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;


        public decimal Price { get; set; }

   
        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }
        public int CategoryId { get; set; }

        public string CreatorId { get; set; } = string.Empty;


    }
}
