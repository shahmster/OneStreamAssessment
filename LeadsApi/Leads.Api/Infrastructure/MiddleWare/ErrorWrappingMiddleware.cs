using Leads.Api.Infrastructure.ResponseWrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Leads.Api.Infrastructure.MiddleWare
{
    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorWrappingMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {


            string Message = string.Empty;
            try
            {
                await _next.Invoke(context);
            }
            catch (TimeoutException ex)
            {
                Log.Error(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                Message = "Operation has timed out";
            }
            catch (UnauthorizedAccessException ex)
            {
                Log.Error(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                Message = ex.Message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                Message = "An unknown error has occured";
            }



            //Can add more catch statements
            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";

                var response = new Response<object>
                {
                    Success = false,
                    Messsage = Message

                };

                var json = JsonConvert.SerializeObject(response);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
