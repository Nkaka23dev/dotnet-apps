using GameStore.Data;
using GameStore.GamesEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conneString = builder.Configuration.GetConnectionString("GameStore");

// builder.Services.AddDbContext<GameStoreContext>(options =>
//  options.UseSqlite(conneString));
builder.Services.AddSqlite<GameStoreContext>(conneString);

var webApp = builder.Build();

webApp.MapGamesEndpoints();

await webApp.MigrateDbAsync();

webApp.Run();

