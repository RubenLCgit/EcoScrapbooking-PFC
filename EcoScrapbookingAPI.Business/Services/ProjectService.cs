using EcoScrapbookingAPI.Business.DTOs.ProjectDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Services;

public class ProjectService : IProjectService
{
  private readonly IRepositoryGeneric<Project> _projectRepository;

  public ProjectService(IRepositoryGeneric<Project> projectRepository)
  {
    _projectRepository = projectRepository;
  }

  public Project CreateProject(ProjectCreateDTO projectCreateDTO)
  {
    var project = new Project(projectCreateDTO.Title, projectCreateDTO.Description, projectCreateDTO.MaxParticipants ?? 0, projectCreateDTO.StartDate, projectCreateDTO.FinishDate, projectCreateDTO.GreenPointsValue, projectCreateDTO.ProjectType, projectCreateDTO.CreatorUserId);
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
    project.GreenPointsValue = projectUpdateDTO.GreenPointsValue ?? project.GreenPointsValue;
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
}