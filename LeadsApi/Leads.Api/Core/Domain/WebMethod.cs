using System.Collections.Generic;

namespace Leads.Api.Core.Domain
{
    public class WebMethod
    {
        public WebMethod()
        {
            LeadsRequestResponseDetails = new HashSet<LeadsRequestResponseDetail>();
        }
        public int WebMethodId { get; set; }
        public int Description { get; set; }
        public virtual ICollection<LeadsRequestResponseDetail> LeadsRequestResponseDetails { get; set; }
    }
}
