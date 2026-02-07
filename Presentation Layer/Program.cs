using E_Commerce.Application.DependencyInjection;
using Serilog;
using E_Commerce.Infreastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console(
        outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .WriteTo.File(
        "Logs/log-.txt",
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 7)
    .CreateLogger();

builder.Host.UseSerilog();
Log.Logger.Information("App Is building...........");

builder.Services.AddControllers();
builder.Services.AddInfreastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

try
{
    var app = builder.Build();

    app.UseSerilogRequestLogging();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "swagger";
    });

    app.MapGet("/", () => Results.Redirect("/swagger"));
    app.UseInfreastructureServices();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    Log.Logger.Information("App is Running..............");
    app.Run();
}
catch (Exception ex)
{
    Log.Logger.Fatal(ex, "App Failed To Start..............");
}
finally
{
    Log.CloseAndFlush();
}