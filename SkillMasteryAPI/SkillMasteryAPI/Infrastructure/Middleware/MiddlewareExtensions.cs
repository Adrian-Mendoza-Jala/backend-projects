using Microsoft.AspNetCore.Builder;

namespace SkillMasteryAPI.Infrastructure.Middleware
{
    public static class MiddlewareExtensions
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
