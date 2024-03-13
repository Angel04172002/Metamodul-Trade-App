using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Message = "Test client request message",
                    Topic = "Test client topic 1",
                    CreatorId = ""
                },
                new ClientRequest()
                {
                    Id = 1,
                    Message = "Test client request message",
                    Topic = "Test client topic 1",
                    CreatorId = ""
                },
                new ClientRequest()
                {
                    Id = 1,
                    Message = "Test client request message",
                    Topic = "Test client topic 1",
                    CreatorId = ""
                },
            };

            return clientRequests;
        }
    }
}
