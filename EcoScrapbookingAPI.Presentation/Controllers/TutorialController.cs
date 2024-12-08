using EcoScrapbookingAPI.Business.DTOs.TutorialsDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoScrapbookingAPI.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class TutorialController : ControllerBase
{
  private readonly ITutorialService _tutorialService;

  public TutorialController(ITutorialService tutorialService)
  {
    _tutorialService = tutorialService;
  }

  [HttpGet]
  public ActionResult<List<TutorialGetDTO>> GetAll()
  {
    try
    {
      var tutorials = _tutorialService.GetAllTutorials();
      return Ok(tutorials);
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

  [HttpGet("{tutorialId}")]
  public ActionResult<TutorialGetDTO> Get(int tutorialId)
  {
    try
    {
      return Ok(_tutorialService.GetTutorial(tutorialId));
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
  public ActionResult<Tutorial> Create([FromBody] TutorialCreateDTO tutorialCreateDTO)
  {
    try
    {
      var tutorial = _tutorialService.CreateTutorial(tutorialCreateDTO);
      return CreatedAtAction(nameof(Get), new { tutorialId = tutorial.ActivityId }, tutorial);
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

  [HttpPut("{tutorialId}")]
  public ActionResult Update(int tutorialId, [FromBody] TutorialUpdateDTO tutorialUpdateDTO)
  {
    try
    {
      _tutorialService.UpdateTutorial(tutorialId, tutorialUpdateDTO);
      return Ok();
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

  [HttpDelete("{tutorialId}")]
  public ActionResult Delete(int tutorialId)
  {
    try
    {
      _tutorialService.DeleteTutorial(tutorialId);
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

  [HttpPost("{tutorialId}/resources/{resourceId}")]
  public ActionResult AddResource(int tutorialId, int resourceId)
  {
    try
    {
      _tutorialService.AddResourceToTutorial(tutorialId, resourceId);
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

  [HttpDelete("{tutorialId}/resources/{resourceId}")]
  public ActionResult RemoveResource(int tutorialId, int resourceId)
  {
    try
    {
      _tutorialService.RemoveResourceFromTutorial(tutorialId, resourceId);
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