using System;
using Leads.Api.Core.Repositories;

namespace Leads.Api.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ILogRequestResponseRepository LogRequestResponseRepository { get; }
        int Complete();
    }
}