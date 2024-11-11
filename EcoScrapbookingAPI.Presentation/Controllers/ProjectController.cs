using EcoScrapbookingAPI.Business.DTOs.ProjectDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoScrapbookingAPI.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{
  private readonly IProjectService _projectService;

  public ProjectController(IProjectService projectService)
  {
    _projectService = projectService;
  }

  [HttpGet]
  public ActionResult<List<ProjectGetDTO>> GetAll()
  {
    try
    {
      var projects = _projectService.GetAllProjects();
      return Ok(projects);
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

  [HttpGet("{projectId}")]
  public ActionResult<ProjectGetDTO> Get(int projectId)
  {
    try
    {
      return Ok(_projectService.GetProject(projectId));
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
  public ActionResult<Project> Create([FromBody] ProjectCreateDTO projectCreateDTO)
  {
    try
    {
      var project = _projectService.CreateProject(projectCreateDTO);
      return CreatedAtAction(nameof(Get), new { projectId = project.ActivityId }, project);
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

  [HttpPut("{projectId}")]
  public ActionResult Update(int projectId, [FromBody] ProjectUpdateDTO projectUpdateDTO)
  {
    try
    {
      _projectService.UpdateProject(projectId, projectUpdateDTO);
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

  [HttpDelete("{projectId}")]
  public ActionResult Delete(int projectId)
  {
    try
    {
      _projectService.DeleteProject(projectId);
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