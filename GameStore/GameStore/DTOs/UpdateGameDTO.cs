namespace GameStore.DTOs;

public record class UpdateGameDTO(
     string Name,
    string Genre,
    decimal Price, 
    DateOnly ReleaseDAte
);
