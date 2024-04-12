using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Core.Models.Comment
{
    public class CommentDeleteFormViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;
    }
}
