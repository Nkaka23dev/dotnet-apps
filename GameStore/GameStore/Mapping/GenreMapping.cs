using GameStore.DTOs;
using GameStore.Entities;

namespace GameStore.Mapping;

public static class GenreMapping
{
 public static GenreReponseDTO ToGenreResponse(this Genre genre){
    return new(genre.Id,genre.Name);
 }
}
