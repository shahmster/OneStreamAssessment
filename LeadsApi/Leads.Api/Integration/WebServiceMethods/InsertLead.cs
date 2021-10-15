using AutoMapper;
using Leads.Api.Dtos;
using Leads.Api.Integration.WebServiceMethod.Abstractions;
using LeadsWebService;
using System.Threading.Tasks;

namespace Leads.Api.Integration.WebServiceMethods
{
    public class InsertLead : IWebServiceMethod<LeadDetails[], string>
    {
        private readonly ServiceSoapClient _client;
        private readonly IMapper _mapper;

        public InsertLead(
            ServiceSoapClient client,
            IMapper mapper)
        {
            this._client = client;
            this._mapper = mapper;
        }
        public async Task<string> ExecuteAsync(LeadDetails[] request)
        {
            var contacts = _mapper.Map<ContactModel[]>(request);
            var result = await _client.InsertLeadAsync(contacts);

            return result.Body.InsertLeadResult;
        }
    }
}
