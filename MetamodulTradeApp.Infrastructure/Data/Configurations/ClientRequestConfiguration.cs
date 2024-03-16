using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetamodulTradeApp.Infrastructure.Data.Configurations
{
    public class ClientRequestConfiguration : IEntityTypeConfiguration<ClientRequest>
    {
        public void Configure(EntityTypeBuilder<ClientRequest> builder)
        {
            builder.HasData(SeedClientRequests());
        }

        private List<ClientRequest> SeedClientRequests()
        {
            List<ClientRequest> clientRequests = new List<ClientRequest>()
            {
                new ClientRequest()
                {
                    Id = 1,
                    Message = "Съобщение от Петър",
                    Topic = "Заявка от Петър",
                    CreatorId = "506cd08d-e8d0-4d5c-9796-949558867648",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    PhoneNumber = "0882426666"
                },
                new ClientRequest()
                {
                    Id = 2,
                    Message = "Съобщение 2 от Петър",
                    Topic = "Заявка 2 от Петър",
                    CreatorId = "506cd08d-e8d0-4d5c-9796-949558867648",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    PhoneNumber = "0882426666"
                },
                new ClientRequest()
                {
                    Id = 3,
                    Message = "Съобщение от Ангел",
                    Topic = "Заявка от Ангел",
                    CreatorId = "ece06352-f235-4345-94a7-1a2c12f03ac6",
                    CreatedOn = DateTime.Now.AddMonths(-2),
                    PhoneNumber = "0888556753"
                },
            };

            return clientRequests;
        }
    }
}
