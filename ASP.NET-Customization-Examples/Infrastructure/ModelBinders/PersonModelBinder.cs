using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Customization_Examples.Data.Entities;

namespace ASP.NET_Customization_Examples.Infrastructure.ModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext is null) throw new ArgumentNullException(nameof(bindingContext));

            if (bindingContext.FieldName is not "person") throw new ArgumentNullException(nameof(bindingContext.FieldName)); ;

            var model = new Person();

            bindingContext.Model = model;

            return Task.CompletedTask;
        }
    }
}
