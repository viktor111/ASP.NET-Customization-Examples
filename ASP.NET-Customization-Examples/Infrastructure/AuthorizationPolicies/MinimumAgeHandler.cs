using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.NET_Customization_Examples.Infrastructure.AuthorizationPolicies
{
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            var user = context.User;

            if (!user.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                return Task.FromResult(0);
            }

            var dateOfBirth = Convert.ToDateTime(user.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);

            int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;

            if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge))
            {
                calculatedAge--;
            }

            if (calculatedAge >= requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }
            return Task.FromResult(0);
        }
    }
}
