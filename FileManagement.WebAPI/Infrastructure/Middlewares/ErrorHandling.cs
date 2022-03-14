﻿
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ValidationException = FileManagement.Core.Exceptions.ValidationException;

namespace FileManagement.API.Infrastructure.Middlewares
{
    public class ErrorHandling
    {
        private readonly RequestDelegate next;
        public ErrorHandling(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(SerializeObject(ex.Failures));

            }
            catch (Exception ex)
            {
                var _logger = loggerFactory.CreateLogger<ErrorHandling>();
                _logger.LogError(ex.ToString());
                await HandledGeneralException(context, ex);
            }
            
        }
        private async Task HandledGeneralException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";
           
            await context.Response.WriteAsync("Error Occurred. Please, check the logs");

        }
        private string SerializeObject(object obj)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
        }
    }
}
