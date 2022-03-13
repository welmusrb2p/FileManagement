
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FileManagement.API.Infrastructure.Middlewares
{
    public class AuthorizationTokenMiddleware
    {
        private readonly RequestDelegate next;

        public AuthorizationTokenMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context, IConfiguration configuration)
        {
            var accessToken = context.Request.Headers[HeaderNames.Authorization];

            if (accessToken.FirstOrDefault()?.ToUpper() != configuration.GetValue<string>("AuthorizationToken").ToUpper())
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Invalid Token");
                return;
            }
            else

                await next(context);
        }
    }
}
