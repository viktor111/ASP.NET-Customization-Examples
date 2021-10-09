using ASP.NET_Customization_Examples.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace ASP.NET_Customization_Examples.Infrastructure
{
    public class GenericControllerFactory : IControllerFactory
    {
        public object CreateController(ControllerContext context)
        {
            throw new NotImplementedException();
        }

        public void ReleaseController(ControllerContext context, object controller)
        {
            throw new NotImplementedException();
        }
    }
}
