namespace GameStore.DTOs;

public record class GameSummaryDTO(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDAte
    );



