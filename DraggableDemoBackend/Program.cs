using DraggableDemoBackend.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddSingleton<DragHub>();

var app = builder.Build();

app.UseRouting();
app.UseCors();
app.MapHub<DragHub>("/drag");

app.Run();
