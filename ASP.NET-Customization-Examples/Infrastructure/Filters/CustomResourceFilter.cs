using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Customization_Examples.Infrastructure.Filters
{
    public class CustomResourceFilter : IResourceFilter
    {
        // Do something after action result
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {              
                return; 
            }
            context.Result.ExecuteResultAsync(context);
        }

        // Do something before model binding
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (context.ActionDescriptor.RouteValues.ContainsKey("id"))
            {
                context.Result = new BadRequestResult();
            }
        }
    }
}
