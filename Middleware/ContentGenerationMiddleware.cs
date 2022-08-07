using App3.Model;

namespace App3.Middleware
{
    //? JSON, String, Binary, HTML, ...
    public class ContentGenerationMiddleware
    {
        private RequestDelegate _next;

        public ContentGenerationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //! Version - 1.0
        //     public async Task InvokeAsync(HttpContext context)
        //     {
        //         //? Security Gaurd
        //         //? 1. Browser Checking 
        //         // var result = context.Request.Headers["User-Agent"].Any(value => value.Contains("Chrome"));
        //         var result = context.Request.Headers["User-Agent"].Any(value => value.Contains("Edg"));

        //         if (result)//!Edge
        //         {
        //             await context.Response.WriteAsync("Edge not support");
        //         }
        //         else
        //         {
        //             var product = new Product
        //             {
        //                 Id = 1,
        //                 Name = "Sample Product"
        //             };

        //             await context.Response.WriteAsJsonAsync(product);
        //         }
        //     }

        //! Version - 2.0
        // public async Task InvokeAsync(HttpContext context)
        // {
        //     //? Generation
        //     var product = new Product
        //     {
        //         Id = 1,
        //         Name = "Sample Product"
        //     };

        //     await context.Response.WriteAsJsonAsync(product);
        // }

        //! Version - 3.0
        // public async Task InvokeAsync(HttpContext context)
        // {
        //     //? Generation
        //     var product = new Product
        //     {
        //         Id = 1,
        //         Name = "Sample Product"
        //     };

        //     context.Items["Content"] = product;
        // }

        //! Version 4.0
        // public void Invoke(HttpContext context)
        // {
        //     //? Generation
        //     var product = new Product
        //     {
        //         Id = 1,
        //         Name = "Sample Product"
        //     };

        //     context.Items["Content"] = product;
        // }    

        //! Version 5.0
        public async Task InvokeAsync(HttpContext context)
        {
            await Task.Run(() =>
            {
                //? Generation
                var product = new Product
                {
                    Id = 1,
                    Name = "Sample Product"
                };

                context.Items["Content"] = product;
            });
        }
    }
}