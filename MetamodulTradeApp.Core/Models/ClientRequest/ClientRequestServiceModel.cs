using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Core.Models.ClientRequest
{
    public class ClientRequestServiceModel
    {
        public int Id { get; set; }

        public string Topic { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string CreatedOn { get; set; } = string.Empty;

        public string Creator { get; set; } = string.Empty;

        public string CreatorId { get; set; } = string.Empty;

    }
}
