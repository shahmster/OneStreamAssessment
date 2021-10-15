using System;
using System.Collections.Generic;

namespace Leads.Api.Core.Domain
{
    public class LeadsRequestResponseDetail
    {
        public LeadsRequestResponseDetail()
        {
            
        }

        public int Id { get; set; }

        public string RequestPayload { get; set; }

        public string ResponsePayload { get; set; }

        public DateTime RequestTimeStamp { get; set; }

        public DateTime ResponseTimeStamp { get; set; }


        public int WebMethodId { get; set; }

       

        public WebMethod WebMethod { get; set; }

       
    }
}
