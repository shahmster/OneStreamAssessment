
using Leads.Api.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leads.Api.Persistence.EntityConfigurations
{
    public class LogLeadsRequestMap : IEntityTypeConfiguration<LeadsRequestResponseDetail>
    {
        public void Configure(EntityTypeBuilder<LeadsRequestResponseDetail> builder)
        {
            builder.ToTable("TM_LogRequestsResponse");
            builder.HasKey(p => p.Id);

            builder.HasOne(e => e.WebMethod)
              .WithMany(e => e.LeadsRequestResponseDetails)
              .HasForeignKey(e => e.WebMethodId)
              .HasConstraintName("FK_WEBMETHOD_LEADSREQUESTRESPONSELOG");

        }
    }
}
