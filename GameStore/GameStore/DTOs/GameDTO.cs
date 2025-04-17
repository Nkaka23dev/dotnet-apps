namespace GameStore.DTOs;

public record class GameDTO(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDAte
    );

