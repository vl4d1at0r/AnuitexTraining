using System;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Common.Interfaces;
using AnuitexTraining.BusinessLogicLayer.Exceptions;
using AnuitexTraining.BusinessLogicLayer.Models.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AnuitexTraining.PresentationLayer.Middlewares
{
    public class ErrorHandleMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

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
                var model = new BaseModel
                {
                    Errors = exception.Errors
                };
                var response = JsonConvert.SerializeObject(model);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) exception.Code;
                await context.Response.WriteAsync(response);
            }
            catch (Exception exception)
            {
                _logger.LogFile(exception.Message);
            }
        }
    }
}