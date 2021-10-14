using Leads.Api.Dtos;
using Leads.Api.Integration.WebServiceMethod.Abstractions;
using LeadsWebService;
using System.Threading.Tasks;

namespace Leads.Api.Integration.WebServiceMethod
{
    public class WebServiceMethod : IWebServiceMethod<DialDetails, string>
    {
        private readonly ServiceSoapClient _client;

        public WebServiceMethod(
            ServiceSoapClient client)
        {
            this._client = client;
        }
        public async Task<string> ExecuteAsync(DialDetails request)
        {
            
            var  result = await _client.DialAsync(request.AgentSessionId, request.PhoneNumber);
            
            return result.Body.DialResult;
        }
    }
}
