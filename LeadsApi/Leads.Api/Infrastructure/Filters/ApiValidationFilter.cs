using Leads.Api.Infrastructure.ResponseWrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leads.Api.Infrastructure.Filters
{
    public class ApiValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new Response<object>
                {
                    ModelValidationErrors = context.ModelState
                        .Select(err => new
                        {
                            field = err.Key,
                            errors = err.Value.Errors
                                .Select(msg => new
                                {
                                    errorMessage = msg.ErrorMessage
                                })
                        })
                });

            }

        }
    }
}
