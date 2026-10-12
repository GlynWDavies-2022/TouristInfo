using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TouristInfo.API.Data;
using TouristInfo.API.Models;

namespace TouristInfo.API.Controllers;

[Route("api/cities/{cityId}/pointsofinterest")]
[ApiController]
public class PointsOfInterestController : ControllerBase
{
    [HttpPost]
    public ActionResult<PointOfInterestDTO> CreatePointOfInterest(int cityId, PointOfInterestForCreationDTO pointOfInterest)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);

        if (city == null)
        {

            return NotFound($"City with id {cityId} was not found");
        }

        var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(city => city.PointsOfInterest).Max(point => point.Id);

        var finalPointOfInterest = new PointOfInterestDTO()
        {
            Id = ++maxPointOfInterestId,
            Name = pointOfInterest.Name,
            Description = pointOfInterest.Description
        };

        city.PointsOfInterest.Add(finalPointOfInterest);

        return CreatedAtRoute(
            "GetPointOfInterest",
            new
            {
                cityId,
                pointOfInterestId = finalPointOfInterest.Id
            },
            finalPointOfInterest
        );
    }

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

    [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
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

    [HttpPut("{pointOfInterestId}")]
    public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId, PointOfInterestForUpdateDTO pointOfInterest)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);

        if (city == null)
        {
            return NotFound($"City with id {cityId} was not found.");
        }

        var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(poi => poi.Id == pointOfInterestId);

        if (pointOfInterestFromStore == null)
        {
            return NotFound($"Point of Interest with id {pointOfInterestId} could not be found!");
        }

        pointOfInterestFromStore.Name = pointOfInterest.Name;
        pointOfInterestFromStore.Description = pointOfInterest.Description;

        return NoContent();
    }

    [HttpDelete("{pointOfInterestId}")]
    public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);

        if (city == null)
        {
            return NotFound($"City with id {cityId} could not be found!");
        }

        var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(poi => poi.Id == pointOfInterestId);

        if (pointOfInterestFromStore == null)
        {
            return NotFound($"Point of Interest with id {pointOfInterestId} could not be found!");
        }

        city.PointsOfInterest.Remove(pointOfInterestFromStore);

        return NoContent();
    }

    [HttpPatch("{pointOfInterestId}")]
    public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId,
        JsonPatchDocument<PointOfInterestForUpdateDTO> patchDocument)
    {
        var city = CitiesDataStore.Current.Cities
            .FirstOrDefault(c => c.Id == cityId);
        if (city is null)
        {
            return NotFound();
        }
        var pointOfInterestFromStore = city.PointsOfInterest
            .FirstOrDefault(c => c.Id == pointOfInterestId);
        if (pointOfInterestFromStore is null)
        {
            return NotFound();
        }

        var pointOfInterestToPatch =
            new PointOfInterestForUpdateDTO()
            {
                Name = pointOfInterestFromStore.Name,
                Description = pointOfInterestFromStore.Description
            };

        patchDocument.ApplyTo(pointOfInterestToPatch, jsonPatchError =>
        {
            var key = jsonPatchError.AffectedObject.GetType().Name;
            ModelState.AddModelError(key, jsonPatchError.ErrorMessage);
        });

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!TryValidateModel(pointOfInterestToPatch))
        {
            return BadRequest(ModelState);
        }

        pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
        pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;
        return NoContent();
    }
}
