using EcoScrapbookingAPI.Business.DTOs.ProjectDTOs;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Interfaces;

public interface IProjectService
{
  Project CreateProject(ProjectCreateDTO projectCreateDTO);
  void UpdateProject(int projectId, ProjectUpdateDTO projectUpdateDTO);
  void DeleteProject(int projectId);
  List<ProjectGetDTO> GetAllProjects();
  ProjectGetDTO GetProject(int projectId);
  void AddResourceToProject(int projectId, int resourceId);
  void RemoveResourceFromProject(int projectId, int resourceId);
}