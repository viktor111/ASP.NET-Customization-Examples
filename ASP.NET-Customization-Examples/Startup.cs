using ASP.NET_Customization_Examples.Infrastructure;
using ASP.NET_Customization_Examples.Infrastructure.AuthorizationPolicies;
using ASP.NET_Customization_Examples.Infrastructure.Filters;
using ASP.NET_Customization_Examples.Infrastructure.ModelBinders;
using ASP.NET_Customization_Examples.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.NET_Customization_Examples
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure custom authorization policy and built in admin policy
            services.AddAuthorization(auth =>
            {
                // Built in
                auth.AddPolicy("Admin", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Admin", "Administrator");
                });

                // Custom
                auth.AddPolicy("Over18", policy => policy.Requirements.Add(new MinimumAgeRequirement(18)));
            });

            services.AddControllersWithViews(options => 
            {
                // Register custom model binder using provider
                options.ModelBinderProviders.Insert(0, new PersonModelBinderProvider());

                // Register custom filters
                options.Filters.Add<CustomResourceFilter>();
            });

            // Need to register custom middleware in services
            services.AddScoped<TokenCheckMiddleware>();

            // Register custom controller factory
            services.AddTransient<IControllerFactory, GenericControllerFactory>();

            // Register custom authorization handler
            services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Custom middleware
            app.UseTokenCheck();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
