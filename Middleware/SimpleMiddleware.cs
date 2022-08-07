namespace App3.Middleware
{
    public class SimpleMiddleware
    {
        private RequestDelegate _next;

        public SimpleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //? Sync
        // public void Invoke(HttpContext context)
        // {
        //     //? Logic
        // }

        public async Task InvokeAsync(HttpContext context)
        {
            //? Pre Process

            //? Main Process
            await context.Response.WriteAsync("Sample Content");
            
            //? Call Pipeline

            //? Post Process
        }
    }
}