using EcoScrapbookingAPI.Business.DTOs.PublicationDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoScrapbookingAPI.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class PublicationController : ControllerBase
{
  private readonly IPublicationService _publicationService;

  public PublicationController(IPublicationService publicationService)
  {
    _publicationService = publicationService;
  }

  [HttpGet]
  public ActionResult<List<PublicationGetDTO>> GetAll()
  {
    try
    {
      var publications = _publicationService.GetAllPublications();
      return Ok(publications);
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

  [HttpGet("{publicationId}")]
  public ActionResult<PublicationGetDTO> Get(int publicationId)
  {
    try
    {
      return Ok(_publicationService.GetPublication(publicationId));
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
  public ActionResult<Publication> Create([FromBody] PublicationCreateDTO publicationCreateDTO)
  {
    try
    {
      var publication = _publicationService.CreatePublication(publicationCreateDTO);
      return CreatedAtAction(nameof(Get), new { publicationId = publication.PublicationId }, publication);
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

  [HttpPut("{publicationId}")]
  public ActionResult Update(int publicationId, [FromBody] PublicationUpdateDTO publicationUpdateDTO)
  {
    try
    {
      _publicationService.UpdatePublication(publicationId, publicationUpdateDTO);
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

  [HttpDelete("{publicationId}")]
  public ActionResult Delete(int publicationId)
  {
    try
    {
      _publicationService.DeletePublication(publicationId);
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