using EcoScrapbookingAPI.Business.DTOs.ProjectDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Services;

public class ProjectService : IProjectService
{
  private readonly IRepositoryGeneric<Project> _projectRepository;
  private readonly IRepositoryGeneric<Material> _materialRepository;
  private readonly IRepositoryGeneric<Tool> _toolRepository;

  public ProjectService(IRepositoryGeneric<Project> projectRepository, IRepositoryGeneric<Material> materialRepository, IRepositoryGeneric<Tool> toolRepository)
  {
    _projectRepository = projectRepository;
    _materialRepository = materialRepository;
    _toolRepository = toolRepository;
  }

  public Project CreateProject(ProjectCreateDTO projectCreateDTO)
  {
    var project = new Project(projectCreateDTO.Title, projectCreateDTO.Description, projectCreateDTO.MaxParticipants ?? 0, projectCreateDTO.StartDate, projectCreateDTO.FinishDate, projectCreateDTO.GreenPointsValue, projectCreateDTO.HomeImageUrl, projectCreateDTO.ProjectType, projectCreateDTO.CreatorUserId);
    _projectRepository.AddEntity(project);
    _projectRepository.SaveChanges();
    return project;
  }

  public void UpdateProject(int projectId, ProjectUpdateDTO projectUpdateDTO)
  {
    var project = _projectRepository.GetByIdEntity(projectId);
    if (project == null) throw new Exception("Project not found");
    project.Title = projectUpdateDTO.Title ?? project.Title;
    project.Description = projectUpdateDTO.Description ?? project.Description;
    project.MaxParticipants = projectUpdateDTO.MaxParticipants ?? project.MaxParticipants;
    project.StartDate = projectUpdateDTO.StartDate ?? project.StartDate;
    project.FinishDate = projectUpdateDTO.FinishDate ?? project.FinishDate;
    project.IsActive = projectUpdateDTO.IsActive ?? project.IsActive;
    project.HomeImageUrl = projectUpdateDTO.HomeImageUrl ?? project.HomeImageUrl;
    project.ProjectType = projectUpdateDTO.ProjectType ?? project.ProjectType;
    _projectRepository.UpdateEntity(project);
    _projectRepository.SaveChanges();
  }

  public void DeleteProject(int projectId)
  {
    var project = _projectRepository.GetByIdEntity(projectId);
    if (project == null) throw new Exception("Project not found");
    _projectRepository.DeleteEntity(project);
    _projectRepository.SaveChanges();
  }

  public List<ProjectGetDTO> GetAllProjects()
  {
    var projects = _projectRepository.GetAllEntities();
    return MapProjectToDTOs(projects);
  }

  private List<ProjectGetDTO> MapProjectToDTOs(List<Project> projects)
  {
    return projects.Select(p => new ProjectGetDTO(p)).ToList();
  }

  public ProjectGetDTO GetProject(int projectId)
  {
    var project = _projectRepository.GetByIdEntity(projectId);
    if (project == null) throw new Exception("Project not found");
    return new ProjectGetDTO(project);
  }

  public void AddResourceToProject(int projectId, int resourceId)
  {
    var project = _projectRepository.GetByIdEntity(projectId);
    if (project == null) throw new Exception("Project not found");
    var material = _materialRepository.GetByIdEntity(resourceId);
    if (material != null)
    {
      if (project.ActivityResources.Contains(material)) throw new Exception("Resource already added to project");
      project.ActivityResources.Add(material);
      material.Activities.Add(project);
      _materialRepository.UpdateEntity(material);
      _projectRepository.UpdateEntity(project);
      _projectRepository.SaveChanges();
      return;
    }
    var tool = _toolRepository.GetByIdEntity(resourceId);
    if (tool != null)
    {
      if (project.ActivityResources.Contains(tool)) throw new Exception("Resource already added to project");
      project.ActivityResources.Add(tool);
      tool.Activities.Add(project);
      _toolRepository.UpdateEntity(tool);
      _projectRepository.UpdateEntity(project);
      _projectRepository.SaveChanges();
      return;
    }
    throw new Exception("Resource not found");
  }

  public void RemoveResourceFromProject(int projectId, int resourceId)
  {
    var project = _projectRepository.GetByIdEntity(projectId);
    if (project == null) throw new Exception("Project not found");
    var material = _materialRepository.GetByIdEntity(resourceId);
    if (material != null)
    {
      if (!project.ActivityResources.Contains(material)) throw new Exception("Resource not added to project");
      project.ActivityResources.Remove(material);
      material.Activities.Remove(project);
      _materialRepository.UpdateEntity(material);
      _projectRepository.UpdateEntity(project);
      _projectRepository.SaveChanges();
      return;
    }
    var tool = _toolRepository.GetByIdEntity(resourceId);
    if (tool != null)
    {
      if (!project.ActivityResources.Contains(tool)) throw new Exception("Resource not added to project");
      project.ActivityResources.Remove(tool);
      tool.Activities.Remove(project);
      _toolRepository.UpdateEntity(tool);
      _projectRepository.UpdateEntity(project);
      _projectRepository.SaveChanges();
      return;
    }
    throw new Exception("Resource not found");
  }
}