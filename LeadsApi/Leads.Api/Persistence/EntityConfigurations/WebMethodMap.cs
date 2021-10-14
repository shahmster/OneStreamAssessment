using Leads.Api.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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