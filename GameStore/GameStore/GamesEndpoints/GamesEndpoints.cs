using GameStore.Data;
using GameStore.DTOs;
using GameStore.Entities;
using GameStore.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GameStore.GamesEndpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("games");

        group.MapGet("/", async (GameStoreContext dbContext) =>
         await dbContext.Games
                    .Include(game => game.Genre)
                    .Select(game => game.ToGameSummaryDTO())
                    .AsNoTracking()
                    .ToListAsync());

        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            Game? game = await dbContext.Games.FindAsync(id);
            return game is null ? Results.NotFound()
             : Results.Ok(game.ToGameDetailsDTO());
        }).WithName(GetGameEndpointName);


        group.MapPost("/", async ([FromBody] CreateGameDTO newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity();
    
            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetGameEndpointName,
               new { id = game.Id }, game.ToGameDetailsDTO());
        });
 

        group.MapPut("/{id}", async ([FromRoute]
         int id, [FromBody] UpdateGameDTO modifyGame,
          GameStoreContext dbContext) =>
        {
            var existingGame = await dbContext.Games.FindAsync(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
              dbContext.Entry(existingGame)
              .CurrentValues.SetValues(modifyGame.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.Ok(existingGame);
        });

        group.MapDelete("/{id}", async ([FromRoute] int id, GameStoreContext dbContext) =>
        {
            await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();

        });
        return group;
    }
}
