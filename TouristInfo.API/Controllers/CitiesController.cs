using Microsoft.AspNetCore.Mvc;
using TouristInfo.API.Data;

namespace TouristInfo.API.Controllers;

[ApiController]
[Route("api/cities")]
public class CitiesController : ControllerBase
{
    [HttpGet]
    public JsonResult GetCities()
    {
        return new JsonResult(CitiesDataStore.Current.Cities);
    }
}
