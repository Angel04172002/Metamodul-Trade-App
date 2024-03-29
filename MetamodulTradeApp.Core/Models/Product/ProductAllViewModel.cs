﻿namespace MetamodulTradeApp.Core.Models.Product
{
    public class ProductAllViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;


        public decimal Price { get; set; }

   
        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public int CategoryId { get; set; }


    }
}
