using GameStore.Data;
using GameStore.DTOs;
using GameStore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.GamesEndpoints;

public static class GenreEndpoints
{
  public static RouteGroupBuilder MapGenreEndpoits(this WebApplication app){
    var group = app.MapGroup("genre");

    group.MapGet("/", async (GameStoreContext dbContext) => 
        await dbContext.Genre
        .Select(genre => genre.ToGenreResponse()).ToListAsync());

    return group;
  } 
}
