using Leads.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leads.Api.Core.Domain.Services
{
    public interface ILeadsService
    {
        Task<string> Dial(DialDetails dialDetails);
        Task<string> Insert(LeadDetails lead);
    }
}
