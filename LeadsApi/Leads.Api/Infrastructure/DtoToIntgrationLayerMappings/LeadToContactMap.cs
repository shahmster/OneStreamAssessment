using AutoMapper;
using Leads.Api.Dtos;
using LeadsWebService;

namespace Leads.Api.Infrastructure.DtoToIntgrationLayerMappings
{
    public class LeadToContactProfile:Profile
    {
        public LeadToContactProfile()
        {
            CreateMap<LeadDetails, ContactModel>();

        }
    }
}
