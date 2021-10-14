using Leads.Api.Core;
using Leads.Api.Core.Domain;
using Leads.Api.Dtos;
using Leads.Api.Integration.WebServiceMethod.Abstractions;
using LeadsWebService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leads.Api.Integration.WebServiceMethod
{
    public class WebServiceMethod : IWebServiceMethod<DialDetails, string>
    {
        private readonly ServiceSoapClient _client;
        private readonly IUnitOfWork _uow;

        public WebServiceMethod(
            ServiceSoapClient client,
            IUnitOfWork uow)
        {
            this._client = client;
            this._uow = uow;
        }
        public async Task<string> ExecuteAsync(DialDetails request)
        {
            
               var  result = await _client.DialAsync(request.AgentSessionId, request.PhoneNumber);
            
            return result.Body.DialResult;
        }
    }
}
