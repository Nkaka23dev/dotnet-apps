using GameStore.Entities;

namespace GameStore.DTOs;

public record GameDetailsDTO(
    int Id,
    string Name,
    int GenreId,
    decimal Price,
    DateOnly ReleaseDAte);
