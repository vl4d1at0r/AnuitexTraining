using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AnuitexTraining.PresentationLayer.Middlewares
{
    public class ErrorHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
        }
    }
}
