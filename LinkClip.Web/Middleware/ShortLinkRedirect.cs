using LinkClip.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace LinkClip.Web.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ShortLinkRedirect
    {
        private readonly RequestDelegate _next;
        private ILinkService _linkService;

        public ShortLinkRedirect(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _linkService = (ILinkService)httpContext.RequestServices.GetService(typeof(ILinkService));
            var userAgent = StringValues.Empty;
            httpContext.Request.Headers.TryGetValue("User-Agent", out userAgent);

            if (httpContext.Request.Path.ToString().Length == 9 && !httpContext.Request.Path.ToString().ToLower().Contains("register"))
            {
                await _linkService.AddUserAgent(userAgent);
                var token = httpContext.Request.Path.ToString().Substring(1);
                var shortUrl =  await _linkService.FindUrlByToken(token);
                await _linkService.AddRequestUrl(token);
                if (shortUrl != null)
                {
                    httpContext.Response.Redirect(shortUrl.OriginalUrl.ToString());
                }
                else
                {
                    httpContext.Response.Redirect(httpContext.Request.Host.ToString());
                }
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ShortLinkRedirectExtensions
    {
        public static IApplicationBuilder UseShortLinkRedirect(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShortLinkRedirect>();
        }
    }
}
