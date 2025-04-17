namespace GameStore.DTOs;

public record class CreateGameDTO( 
    string Name,
    string Genre,
    decimal Price, 
    DateOnly ReleaseDAte
    );
