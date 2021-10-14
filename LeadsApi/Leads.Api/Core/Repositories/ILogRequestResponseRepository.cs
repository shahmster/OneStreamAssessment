using System.Collections.Generic;
using Leads.Api.Core.Domain;

namespace Leads.Api.Core.Repositories
{
    public interface ILogRequestResponseRepository : IRepository<LeadsRequestResponseDetail>
    {
        
        IEnumerable<LeadsRequestResponseDetail> GetLogDetails(int pageIndex, int pageSize);
    }
}