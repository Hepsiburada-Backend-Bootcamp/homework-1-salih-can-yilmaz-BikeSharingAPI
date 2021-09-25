using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;

        private const string APIKEYNAME = "Authorization";
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var requestApiKey))
                {
                    context.Response.StatusCode = 401;
                    return;
                }

                if (requestApiKey != "dummy")
                {
                    context.Response.StatusCode = 401;
                    return;
                }
                else
                {
                    await _next(context);
                }
            }
            catch (System.Exception ex)
            {
                context.Response.StatusCode = 500;
            }
        }
    }
}

