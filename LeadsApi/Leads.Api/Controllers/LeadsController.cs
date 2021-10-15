using Leads.Api.Controllers.Base;
using Leads.Api.Core.Domain.Services;
using Leads.Api.Dtos;
using Leads.Api.Integration.WebServiceMethod.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Leads.Api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class LeadsController : ApiBaseController
    {


        private readonly ILogger<LeadsController> _logger;
        private readonly ILeadsService _leadsService;

        public LeadsController(ILogger<LeadsController> logger, ILeadsService leadsService)
        {
            _logger = logger;
            this._leadsService = leadsService;
            
        }
        [Route("Dail")]
        [HttpPost]
        public async Task<IActionResult> Dial([FromBody] DialDetails dialDetails)
        {
            var response = await _leadsService.Dial(dialDetails);
            
            return Ok(Success("Succesfully Dialed Lead",new
            {
                response
            }));
        }

        [Route("Insert")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] LeadDetails lead)
        {
            var response = await _leadsService.Insert(lead);

            return Ok(new
            {
                response
            });
        }
    }
}
