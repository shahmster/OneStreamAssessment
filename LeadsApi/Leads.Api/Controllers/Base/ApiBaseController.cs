using Leads.Api.Infrastructure.ResponseWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leads.Api.Controllers.Base
{
    public class ApiBaseController
    {

        protected Response<T> Success<T>(string message = null, T Data = null) where T : class => new Response<T>
        {
            Success = true,
            Data = Data,
            Messsage = message ?? "request successful"
        };

        protected Response<T> Failed<T>(string message = null, T Data = null) where T : class => new Response<T>
        {
            Success = false,
            Data = Data,
            Messsage = message ?? "request unsuccessful"
        };

        protected Response<object> Success(string message) => new Response<object>
        {
            Success = true,
            Data = null,
            Messsage = message
        };

    }
}
