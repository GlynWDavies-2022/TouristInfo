using TouristInfo.API.Models;

namespace TouristInfo.API.Data;

public class CitiesDataStore
{
    public static CitiesDataStore Current { get; } = new();

    public List<CityDTO> Cities { get; set; }

    public CitiesDataStore()
    {
        Cities = 
        [
            new()
            {
                Id = 1,
                Name = "New York City",
                Description = "The one with that big park."
            },
            new()
            {
                Id = 2,
                Name = "Antwerp",
                Description = "The one with the cathedral that was never really finished."
            },
            new()
            {
                Id = 3,
                Name = "Paris",
                Description = "The one with that big tower."
            }
        ];
    }
}
