using AnuitexTraining.BusinessLogicLayer.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace AnuitexTraining.PresentationLayer.Middlewares
{
    public class ErrorHandleMiddleware
    {
        ILogger _logger;
        private readonly RequestDelegate _next;

        public ErrorHandleMiddleware(RequestDelegate next, ILogger logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                _logger.LogFile(exception.Message);
            }
        }
    }
}
