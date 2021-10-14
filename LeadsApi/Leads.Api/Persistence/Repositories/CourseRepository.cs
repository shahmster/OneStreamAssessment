using System.Collections.Generic;
using System.Linq;
using Leads.Api.Core.Domain;
using Leads.Api.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Leads.Api.Persistence.Repositories
{
    public class LogRequestResponseRepository : Repository<LeadsRequestResponseDetail>, ILogRequestResponseRepository
    {
        public LogRequestResponseRepository(LeadsDbContext context) 
            : base(context)
        {
        }


        public IEnumerable<LeadsRequestResponseDetail> GetLogDetails(int pageIndex, int pageSize)
        {
            return LeadsDbContext.LeadsRequestResponseDetails
               .Include(c => c.WebMethodId)
               .Skip((pageIndex - 1) * pageSize)
               .Take(pageSize)
               .ToList();
        }

        public LeadsDbContext LeadsDbContext
        {
            get { return Context as LeadsDbContext; }
        }
    }
}