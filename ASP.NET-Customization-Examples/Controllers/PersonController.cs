using ASP.NET_Customization_Examples.Data.Entities;
using ASP.NET_Customization_Examples.Infrastructure.Filters;
using ASP.NET_Customization_Examples.Infrastructure.ModelBinders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Customization_Examples.Controllers
{
    // Using custom policy
    [Authorize("Over18")]
    public class PersonController : Controller
    {
        // Register filter as attribute and retain access to DPI in filter
        [ServiceFilter(typeof(CustomResourceFilter))]
        public IActionResult Index([ModelBinder(typeof(PersonModelBinder))] Person person)
        {
            return View();
        }
    }
}
