using Leads.Api.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leads.Api.Persistence.EntityConfigurations
{
    public class WebMethodMap : IEntityTypeConfiguration<WebMethod>
    {
        public void Configure(EntityTypeBuilder<WebMethod> builder)
        {
            builder.ToTable("TR_WebMethod");
            builder.HasKey(key => key.WebMethodId);

          

        }
    }

}