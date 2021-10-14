using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leads.Api.Integration.WebServiceMethod.Abstractions
{
    public interface IWebServiceMethod<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}
