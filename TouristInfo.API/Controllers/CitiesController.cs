namespace TouristInfo.API.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/cities")]
public class CitiesController : ControllerBase
{
    [HttpGet()]
    public JsonResult GetCities()
    {
        return new JsonResult(
            new[]
            {
                new { id = 1, Name = "New York City"},
                new { id = 2, Name = "Antwerp" }
            }
        );
    }
}
