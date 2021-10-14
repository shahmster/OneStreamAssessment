using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leads.Api.Infrastructure.ResponseWrapper
{
    public class Response<T>
     where T : class
    {
        public bool Success { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Messsage { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object ModelValidationErrors { get; set; }

    }
}
