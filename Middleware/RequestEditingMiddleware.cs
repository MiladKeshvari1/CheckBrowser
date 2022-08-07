using App3.Model;

namespace App3.Middleware
{
    public class RequestEditingMiddleware
    {
        private RequestDelegate _next;

        public RequestEditingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //? Security Gaurd
            //? 1. Browser Checking 
            // var result = context.Request.Headers["User-Agent"].Any(value => value.Contains("Edg"));
            var result = context.Request.Headers["User-Agent"].Any(value => value.Contains("Trident"));
            //? Data Exchange
            context.Items["InvalidBrowser"] = result;

            //? Pipeline
            await _next.Invoke(context);
        }
    }
}