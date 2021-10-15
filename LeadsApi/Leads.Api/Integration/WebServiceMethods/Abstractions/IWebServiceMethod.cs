using System.Threading.Tasks;

namespace Leads.Api.Integration.WebServiceMethod.Abstractions
{
    public interface IWebServiceMethod<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}
