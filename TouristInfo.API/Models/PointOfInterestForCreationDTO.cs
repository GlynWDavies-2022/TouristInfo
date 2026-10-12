using System.ComponentModel.DataAnnotations;

namespace TouristInfo.API.Models;

public class PointOfInterestForCreationDTO
{
    [Required(ErrorMessage = "You must provide a name value.")]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Description { get; set; }
}
