using ASP.NET_Customization_Examples.Data.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Customization_Examples.Infrastructure.ModelBinders
{
    public class PersonModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Person))
            {
                return new BinderTypeModelBinder(typeof(PersonModelBinderProvider));
            }

            return null;
        }
    }
}
