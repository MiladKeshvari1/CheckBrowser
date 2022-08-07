using App3.Middleware;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

//? Middleware Registration
// app.UseMiddleware<SimpleMiddleware>();


app.UseMiddleware<ResponseEditingMiddleware>();//1.0
app.UseMiddleware<RequestEditingMiddleware>();//1.0
app.UseMiddleware<ShortCercuitMiddleware>();//2.0
app.UseMiddleware<ContentGenerationMiddleware>();//3.0

app.Run();