using AnuitexTraining.PresentationLayer.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace AnuitexTraining.PresentationLayer.Extensions
{
    public static class ErrorHandleExtensions
    {
        public static IApplicationBuilder UseErrorHandle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandleMiddleware>();
        }
    }
}
