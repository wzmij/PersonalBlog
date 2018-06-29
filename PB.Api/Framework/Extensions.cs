using Microsoft.AspNetCore.Builder;

namespace PB.Api.Framework
{
    public static class Extensions
    {
        public static IApplicationBuilder UseCustomExtensionHandler(this IApplicationBuilder app)
            => app.UseMiddleware(typeof(CustomExceptionHandlerMiddleware));
    }
}