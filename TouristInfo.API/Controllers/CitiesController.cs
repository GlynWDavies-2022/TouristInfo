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
            new[]
            {
                new { Id = 1, Name = "New York" },
                new { Id = 2, Name = "Antwerp" }
            });
    }
}
