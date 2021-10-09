using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ASP.NET_Customization_Examples.Middleware
{
    public class TokenCheckMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public TokenCheckMiddleware(ILogger logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!context.Request.Headers.ContainsKey("Hidden-Token"))
            {
                context.Request.Headers["Hidden-Token"] = "tokenvalue";
            }

            await next(context);
        }
    }

    public static class TokenCheckMiddlewareExtensions
    {
        // Register middleware by calling this method
        public static IApplicationBuilder UseTokenCheck(this IApplicationBuilder app)
        {
            app.UseMiddleware<TokenCheckMiddleware>();

            return app;
        }
    }
}
