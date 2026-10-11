namespace TouristInfo.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using TouristInfo.API.Data;

[ApiController]
[Route("api/cities")]
public class CitiesController : ControllerBase
{
    [HttpGet()]
    public JsonResult GetCities()
    {
        return new JsonResult(CitiesDataStore.Current.Cities);
    }

    [HttpGet("{id}")]
    public JsonResult GetCity(int id)
    {
        return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(city  => city.Id == id));
    }
}
