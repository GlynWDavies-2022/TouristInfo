namespace TouristInfo.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using TouristInfo.API.Data;
using TouristInfo.API.Models;

[ApiController]
[Route("api/cities")]
public class CitiesController : ControllerBase
{
    [HttpGet()]
    public ActionResult<IEnumerable<CityDTO>> GetCities()
    {
        return Ok(CitiesDataStore.Current.Cities);
    }

    [HttpGet("{id}")]
    public ActionResult<CityDTO> GetCity(int id)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(city  => city.Id == id);

        if (city is null)
        {
            return NotFound($"City with id {id} was not found!");
        }

        return Ok(city);
    }
}
