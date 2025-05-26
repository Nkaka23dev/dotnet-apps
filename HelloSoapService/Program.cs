using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using HelloSoapService.Services;


var builder = WebApplication.CreateBuilder(args);

// Add CoreWCF servicess
builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();

builder.Services.AddSingleton<IPerson, PersonService>();

var app = builder.Build();

app.UseServiceModel(builder =>
{
    builder.AddService<PersonService>();
    builder.AddServiceEndpoint<PersonService, IPerson>(
        new BasicHttpBinding(), "/GreetingService.svc");
    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpGetEnabled = true;
});

app.Run();
