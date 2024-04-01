namespace MetamodulTradeApp.Core.Models.ClientRequest
{
    public class ClientRequestAllViewModel
    {

        public int Id { get; set; }

   
        public string Topic { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string CreatedOn { get; set; } = string.Empty;

        public string CreatorId { get; set; } = string.Empty;


    }
}
