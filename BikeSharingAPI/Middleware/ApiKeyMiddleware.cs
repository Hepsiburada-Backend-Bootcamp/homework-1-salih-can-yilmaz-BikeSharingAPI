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

        /// <summary>
        /// Request lifecycle buradan baslar ve en son olarak yine buradan cikar. Dolayisiyla burada API Key kontrolu eklenmistir.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>401 if not authorized; 500 if there is an exception</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                
                #if DEBUG
                
                    await _next(context);

                #else

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

                #endif
            }
            catch (System.Exception ex)
            {
                context.Response.StatusCode = 500;
            }
        }
    }
}

