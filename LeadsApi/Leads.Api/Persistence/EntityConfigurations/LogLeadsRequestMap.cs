
using Leads.Api.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Bank.Cdv.Data.EntityToDbMaps
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
