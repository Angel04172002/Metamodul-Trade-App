using MetamodulTradeApp.Core.Models.Post;
using MetamodulTradeApp.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Core.Models.Admin
{
    public class MyProductsViewModel
    {
        public IEnumerable<ProductServiceModel> Products { get; set; }
            = new List<ProductServiceModel>();
    }
}
