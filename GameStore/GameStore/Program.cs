using GameStore.DTOs;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDTO> games = [
    new GameDTO(1, "The Witcher 3", "RPG", 29.99m, new DateOnly(2015, 5, 19)),
    new GameDTO(2, "Minecraft", "Sandbox", 19.99m, new DateOnly(2011, 11, 18)),
    new GameDTO(3, "FIFA 24", "Sports", 59.99m, new DateOnly(2023, 9, 29)),
    new GameDTO(4, "God of War", "Action", 49.99m, new DateOnly(2018, 4, 20)),
    new GameDTO(5, "Hades", "Roguelike", 24.99m, new DateOnly(2020, 9, 17))
];

//GET /games
app.MapGet("/games", () => games);

//GET /games/id
app.MapGet("games/{id}", (int id) => games.Find(e => e.Id == id)).WithName(GetGameEndpointName);

//POST /games
app.MapPost("games", ([FromBody] CreateGameDTO newGame) => {
   GameDTO game = new (
     games.Count + 1,
     newGame.Name,
     newGame.Genre,
     newGame.Price,
     newGame.ReleaseDAte
   );
   games.Add(game);
   return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
});
//PUT /games/id
app.MapPut("games/{id}", ([FromRoute] int id, [FromBody] UpdateGameDTO modifyGame) => {
   var gameIndex = games.FindIndex(e => e.Id == id);
   games[gameIndex] = new GameDTO(
      id,
      modifyGame.Name,
      modifyGame.Genre,
      modifyGame.Price,
      modifyGame.ReleaseDAte
   );
   return Results.Ok(games[gameIndex]);
});

app.Run();
