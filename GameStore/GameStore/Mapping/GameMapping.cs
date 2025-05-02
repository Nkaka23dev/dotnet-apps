using GameStore.DTOs;
using GameStore.Entities;

namespace GameStore.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDTO createGameDTO)
    {
        return new()
        {
            Name = createGameDTO.Name,
            GenreId = createGameDTO.GenreId,
            Price = createGameDTO.Price,
            ReleaseDate = createGameDTO.ReleaseDAte
        };
    }
    public static Game ToEntity(this UpdateGameDTO UpdateGameDTO, int id)
    {
        return new()
        { 
            Id = id,
            Name = UpdateGameDTO.Name,
            GenreId = UpdateGameDTO.GenreId,
            Price = UpdateGameDTO.Price,
            ReleaseDate = UpdateGameDTO.ReleaseDAte
        };
    }
    public static GameSummaryDTO ToGameSummaryDTO(this Game game)
    {
        return new(
          game.Id,
          game.Name,
          game.Genre!.Name,
          game.Price,
          game.ReleaseDate
        );
    }
    public static GameDetailsDTO ToGameDetailsDTO(this Game game)
    {
        return new(
         game.Id,
         game.Name,
         game.GenreId!,
         game.Price,
         game.ReleaseDate
       );
    }

}
