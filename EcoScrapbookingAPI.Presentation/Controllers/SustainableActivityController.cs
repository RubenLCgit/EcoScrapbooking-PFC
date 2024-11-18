using EcoScrapbookingAPI.Business.DTOs.SustainableActivityDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoScrapbookingAPI.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class SustainableActivityController : ControllerBase
{
  private readonly ISustainableActivityService _sustainableActivityService;

  public SustainableActivityController(ISustainableActivityService sustainableActivityService)
  {
    _sustainableActivityService = sustainableActivityService;
  }

  [HttpGet]
  public ActionResult<List<SustainableActivityGetDTO>> GetAll()
  {
    try
    {
      var sustainableActivities = _sustainableActivityService.GetAllSustainableActivities();
      return Ok(sustainableActivities);
    }
    catch (ArgumentNullException anEx)
    {
      return NotFound(anEx.Message);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpGet("{sustainableActivityId}")]
  public ActionResult<SustainableActivityGetDTO> Get(int sustainableActivityId)
  {
    try
    {
      return Ok(_sustainableActivityService.GetSustainableActivity(sustainableActivityId));
    }
    catch (ArgumentNullException anEx)
    {
      return NotFound(anEx.Message);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPost]
  public ActionResult<SustainableActivity> Create([FromBody] SustainableActivityCreateDTO sustainableActivityCreateDTO)
  {
    try
    {
      var sustainableActivity = _sustainableActivityService.CreateSustainableActivity(sustainableActivityCreateDTO);
      return CreatedAtAction(nameof(Get), new { sustainableActivityId = sustainableActivity.ActivityId }, sustainableActivity);
    }
    catch (ArgumentNullException anEx)
    {
      return NotFound(anEx.Message);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPut("{sustainableActivityId}")]
  public ActionResult Update(int sustainableActivityId, [FromBody] SustainableActivityUpdateDTO sustainableActivityUpdateDTO)
  {
    try
    {
      _sustainableActivityService.UpdateSustainableActivity(sustainableActivityId, sustainableActivityUpdateDTO);
      return NoContent();
    }
    catch (ArgumentNullException anEx)
    {
      return NotFound(anEx.Message);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpDelete("{sustainableActivityId}")]
  public ActionResult Delete(int sustainableActivityId)
  {
    try
    {
      _sustainableActivityService.DeleteSustainableActivity(sustainableActivityId);
      return NoContent();
    }
    catch (ArgumentNullException anEx)
    {
      return NotFound(anEx.Message);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPost("{sustainableActivityId}/resources/{resourceId}")]
  public ActionResult AddResource(int sustainableActivityId, int resourceId)
  {
    try
    {
      _sustainableActivityService.AddResourceToSustainableActivity(sustainableActivityId, resourceId);
      return NoContent();
    }
    catch (ArgumentNullException anEx)
    {
      return NotFound(anEx.Message);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpDelete("{sustainableActivityId}/resources/{resourceId}")]
  public ActionResult RemoveResource(int sustainableActivityId, int resourceId)
  {
    try
    {
      _sustainableActivityService.RemoveResourceFromSustainableActivity(sustainableActivityId, resourceId);
      return NoContent();
    }
    catch (ArgumentNullException anEx)
    {
      return NotFound(anEx.Message);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}