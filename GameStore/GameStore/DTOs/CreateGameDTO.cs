using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs;

public record class CreateGameDTO( 
    [Required][StringLength(50)]string Name,
    [Required][StringLength(50)]string Genre,
    [Required][Range(0,100)]decimal Price, 
    DateOnly ReleaseDAte
    );
