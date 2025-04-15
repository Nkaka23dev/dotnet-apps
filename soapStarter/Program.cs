using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)
.CreateBootstrapLogger();

try
{
    Log.Information("Starting SOAP webserver....");
    builder.Host.UseSerilog((hostContext, services, configuration) =>
    {
        configuration.ReadFrom.Configuration(builder.Configuration);
    });

    builder.Services.AddControllers()
    .AddXmlSerializerFormatters();

    var app = builder.Build();
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");

}
finally
{
    Log.CloseAndFlush();

}


