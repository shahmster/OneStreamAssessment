using AutoMapper;
using Leads.Api.Dtos;
using LeadsWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
