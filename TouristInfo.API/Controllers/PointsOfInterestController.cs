using Microsoft.AspNetCore.Mvc;
using TouristInfo.API.Data;
using TouristInfo.API.Models;

namespace TouristInfo.API.Controllers;

[Route("api/cities/{cityId}/pointsofinterest")]
[ApiController]
public class PointsOfInterestController : ControllerBase
{
    [HttpGet()]
    public ActionResult<IEnumerable<PointOfInterestDTO>> GetPointsOfInterest(int cityId)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);

        if (city == null)
        {
            return NotFound($"City with id {cityId} was not found.");
        }

        var pointsOfInterest = city.PointsOfInterest.ToList();

        return Ok(pointsOfInterest);
    }

    [HttpGet("{pointOfInterestId}")]
    public ActionResult<PointOfInterestDTO> GetPointOfInterest(int cityId, int pointOfInterestId)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);

        if (city == null)
        {
            return NotFound($"City with id {cityId} was not found.");
        }

        var pointOfInterest = city.PointsOfInterest.FirstOrDefault(poe => poe.Id == pointOfInterestId);

        if (pointOfInterest == null)
        {
            return NotFound($"Point of Interest with id {pointOfInterestId} on city with id of {cityId} was not found");
        }

        return Ok(pointOfInterest);
    }
}
