using EcoScrapbookingAPI.Business.DTOs.MaterialDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoScrapbookingAPI.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class MaterialController : ControllerBase
{
  private readonly IMaterialService _materialService;

  public MaterialController(IMaterialService materialService)
  {
    _materialService = materialService;
  }

  [HttpGet]
  public ActionResult<List<MaterialGetDTO>> GetAll()
  {
    try
    {
      var materials = _materialService.GetAllMaterials();
      return Ok(materials);
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

  [HttpGet("{materialId}")]
  public ActionResult<MaterialGetDTO> Get(int materialId)
  {
    try
    {
      return Ok(_materialService.GetMaterial(materialId));
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
  public ActionResult<Material> Create([FromBody] MaterialCreateDTO materialCreateDTO)
  {
    try
    {
      var material = _materialService.CreateMaterial(materialCreateDTO);
      return CreatedAtAction(nameof(Get), new { materialId = material.ResourceId }, material);
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

  [HttpPut("{materialId}")]
  public ActionResult Update(int materialId, [FromBody] MaterialUpdateDTO materialUpdateDTO)
  {
    try
    {
      _materialService.UpdateMaterial(materialId, materialUpdateDTO);
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

  [HttpDelete("{materialId}")]
  public ActionResult Delete(int materialId)
  {
    try
    {
      _materialService.DeleteMaterial(materialId);
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
}