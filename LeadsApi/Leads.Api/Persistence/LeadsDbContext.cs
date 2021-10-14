
using IS.Bank.Cdv.Data.EntityToDbMaps;
using Leads.Api.Core.Domain;
using Leads.Api.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Leads.Api.Persistence
{
    public class LeadsDbContext : DbContext
    {
        public LeadsDbContext(DbContextOptions<LeadsDbContext> options): base(options)
        {
        }

       
        public virtual DbSet<LeadsRequestResponseDetail> LeadsRequestResponseDetails { get; set; }
        public virtual DbSet<WebMethod> WebMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LogLeadsRequestMap());
            modelBuilder.ApplyConfiguration(new WebMethodMap());
        }
    }
}
