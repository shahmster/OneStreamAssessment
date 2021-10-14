using Leads.Api.Core;
using Leads.Api.Core.Repositories;
using Leads.Api.Persistence.Repositories;

namespace Leads.Api.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeadsDbContext _context;

        public UnitOfWork(LeadsDbContext context)
        {
            _context = context;
            LogRequestResponseRepository = new LogRequestResponseRepository(_context);
        }

        public ILogRequestResponseRepository LogRequestResponseRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}