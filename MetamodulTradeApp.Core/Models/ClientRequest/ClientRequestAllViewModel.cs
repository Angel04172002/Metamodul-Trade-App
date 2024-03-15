namespace MetamodulTradeApp.Core.Models.ClientRequest
{
    public class ClientRequestAllViewModel
    {

        public int Id { get; set; }

   
        public string Topic { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; } = string.Empty;


    }
}
