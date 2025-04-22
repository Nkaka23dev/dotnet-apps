using GameStore.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.GamesEndpoints;

public static class GamesEndpoints
{
 const string GetGameEndpointName = "GetGame";

private static readonly List<GameDTO> games = [
    new GameDTO(1, "The Witcher 3", "RPG", 29.99m, new DateOnly(2015, 5, 19)),
    new GameDTO(2, "Minecraft", "Sandbox", 19.99m, new DateOnly(2011, 11, 18)),
    new GameDTO(3, "FIFA 24", "Sports", 59.99m, new DateOnly(2023, 9, 29)),
    new GameDTO(4, "God of War", "Action", 49.99m, new DateOnly(2018, 4, 20)),
    new GameDTO(5, "Hades", "Roguelike", 24.99m, new DateOnly(2020, 9, 17))
];
public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app){

 var group = app.MapGroup("games");
  //GET /games
group.MapGet("/", () => games);

//GET /games/id
group.MapGet("/{id}", (int id) =>  {
   GameDTO? game =  games.Find(e => e.Id == id);
  return game is null? Results.NotFound(): Results.Ok(game);
}).WithName(GetGameEndpointName);

//POST /games
group.MapPost("/", ([FromBody] CreateGameDTO newGame) => {
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
group.MapPut("/{id}", ([FromRoute] int id, [FromBody] UpdateGameDTO modifyGame) => {
   var gameIndex = games.FindIndex(e => e.Id == id);
   if(gameIndex == -1){
     return Results.NotFound();
   }
   games[gameIndex] = new GameDTO(
      id,
      modifyGame.Name,
      modifyGame.Genre,
      modifyGame.Price,
      modifyGame.ReleaseDAte
   );
   return Results.Ok(games[gameIndex]);
});

group.MapDelete("/{id}", ([FromRoute] int id) => {
   //  var itemToDelete = games.FindIndex(e => e.Id == id);
   //  games.RemoveAt(itemToDelete);
    games.RemoveAll(e => e.Id == id);
    return Results.NoContent();

});
return group;
}
}
