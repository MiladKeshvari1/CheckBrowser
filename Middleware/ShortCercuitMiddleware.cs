using App3.Model;

namespace App3.Middleware
{
    public class ShortCercuitMiddleware
    {
        private RequestDelegate _next;

        public ShortCercuitMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //! Version - 1.0
        // public async Task InvokeAsync(HttpContext context)
        // {
        //     //? Security Gaurd
        //     //? 1. Browser Checking 
        //     // var result = context.Request.Headers["User-Agent"].Any(value => value.Contains("Chrome"));
        //     var result = context.Request.Headers["User-Agent"].Any(value => value.Contains("Edg"));

        //     if (result)//!Edge
        //     {
        //         await context.Response.WriteAsync("Edge not support");
        //     }
        //     else
        //     {
        //         //? Pipeline

        //         await _next.Invoke(context);
        //     }

        //! Version - 2.0
        // public async Task InvokeAsync(HttpContext context)
        // {
        //     var result = context.Items["InvalidBrowser"] as bool?;

        //     if (!result.HasValue)
        //     {
        //         throw new InvalidOperationException("RequestEditingMiddleware not registered!");
        //     }
        //     else if (result.Value)
        //     {
        //         await context.Response.WriteAsync("Edge not support");
        //     }
        //     else
        //     {
        //         //? Pipeline

        //         await _next.Invoke(context);
        //     }
        // }

        //! Version - 3.0
        public async Task InvokeAsync(HttpContext context)
        {
            var result = context.Items["InvalidBrowser"] as bool?;

            if (!result.HasValue)
            {
                throw new InvalidOperationException("RequestEditingMiddleware not registered!");
            }
            else if (result.Value)
            {
                context.Items["Reject"] = "Edge not support";
            }
            else
            {
                //? Pipeline

                await _next.Invoke(context);
            }
        }

    }
}