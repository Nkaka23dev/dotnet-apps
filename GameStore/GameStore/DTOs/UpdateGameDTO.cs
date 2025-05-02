using System.ComponentModel.DataAnnotations;
namespace GameStore.DTOs;

public record class UpdateGameDTO(
    [Required][StringLength(50)] string Name,
    int GenreId,
    [Required][Range(0, 100)] decimal Price,
    DateOnly ReleaseDAte
);
