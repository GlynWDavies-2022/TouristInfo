using Microsoft.AspNetCore.Mvc;

namespace TouristInfo.API.Controllers;

[ApiController]
[Route("api/cities")]
public class CitiesController : ControllerBase
{
    [HttpGet]
    public JsonResult GetCities()
    {
        return new JsonResult(
            new List<object>
            {
                new { CityName = "New York" },
                new { CityName = "Paris" },
                new { CityName = "London" }
            }
        );
    }
}