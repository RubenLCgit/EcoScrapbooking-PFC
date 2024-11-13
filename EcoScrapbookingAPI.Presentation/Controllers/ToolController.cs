using EcoScrapbookingAPI.Business.DTOs.ToolDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoScrapbookingAPI.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ToolController : ControllerBase
{
  private readonly IToolService _toolService;

  public ToolController(IToolService toolService)
  {
    _toolService = toolService;
  }

  [HttpGet]
  public ActionResult<List<ToolGetDTO>> GetAll()
  {
    try
    {
      var tools = _toolService.GetAllTools();
      return Ok(tools);
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

  [HttpGet("{toolId}")]
  public ActionResult<ToolGetDTO> Get(int toolId)
  {
    try
    {
      return Ok(_toolService.GetTool(toolId));
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
  public ActionResult<Tool> Create([FromBody] ToolCreateDTO toolCreateDTO)
  {
    try
    {
      var tool = _toolService.CreateTool(toolCreateDTO);
      return CreatedAtAction(nameof(Get), new { toolId = tool.ResourceId }, tool);
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

  [HttpPut("{toolId}")]
  public ActionResult Update(int toolId, [FromBody] ToolUpdateDTO toolUpdateDTO)
  {
    try
    {
      _toolService.UpdateTool(toolId, toolUpdateDTO);
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

  [HttpDelete("{toolId}")]
  public ActionResult Delete(int toolId)
  {
    try
    {
      _toolService.DeleteTool(toolId);
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