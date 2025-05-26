var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers(); // <- Required for controllers
builder.Services.AddEndpointsApiExplorer(); // Optional, for Swagger
         // Optional, for Swagger

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    Console.Write("Helo");
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map controllers
app.MapControllers(); // <- This activates the controller routes

app.Run();
