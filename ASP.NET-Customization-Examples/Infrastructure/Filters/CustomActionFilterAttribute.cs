using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Customization_Examples.Infrastructure.Filters
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var actionArguments = context.ActionArguments;

            if (!actionArguments.ContainsKey("name"))
            {               
                return;
            }

            // Do something before the action      
            await next();
            // Do something after the action
        }
    }
}
