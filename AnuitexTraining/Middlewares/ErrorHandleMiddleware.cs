using AnuitexTraining.BusinessLogicLayer.Common.Interfaces;
using AnuitexTraining.BusinessLogicLayer.Exceptions;
using AnuitexTraining.BusinessLogicLayer.Models.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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
            catch (UserException exception)
            {
                BaseModel model = new BaseModel
                {
                    Errors = exception.Errors
                };
                string response = JsonConvert.SerializeObject(model);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)exception.Code;
                await context.Response.WriteAsync(response);
            }
            catch (Exception exception)
            {
                _logger.LogFile(exception.Message);
            }
        }
    }
}
