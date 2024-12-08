using EcoScrapbookingAPI.Data.Context;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoScrapbookingAPI.Data.Repositories;

public class ProjectRepository : IRepositoryGeneric<Project>
{
  private readonly EcoScrapbookingDBContext _context;

  public ProjectRepository(EcoScrapbookingDBContext context)
  {
    _context = context;
  }

  public void AddEntity(Project project)
  {
    if (project == null) throw new ArgumentNullException(nameof(project), "The project to be added cannot be null.");
    try
    {
      _context.Projects.Add(project);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error adding project: {project.Title}", dbEx);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error adding project: {project.Title}", odEx);
    }
  }

  public Project? GetByIdEntity(int projectId)
  {
    if (projectId <= 0) throw new ArgumentException("Project ID must be greater than zero.", nameof(projectId));
    try
    {
      return _context.Projects
          .Include(p => p.Publications)
          .Include(p => p.Participants)
          .Include(p => p.ActivityResources)
          .FirstOrDefault(p => p.ActivityId == projectId);
    }
    catch (Exception ex)
    {
      throw new Exception($"Error getting project with ID {projectId}.", ex);
    }
  }

  public void UpdateEntity(Project project)
  {
    try
    {
      _context.Projects.Update(project);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error updating project: {project.Title}", dbEx);
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException($"Error updating project: {project.Title}", ioEx);
    }
  }

  public void DeleteEntity(Project project)
  {
    try
    {
      _context.Projects.Remove(project);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error deleting project: {project.Title}", dbEx);
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException($"Error deleting project: {project.Title}", ioEx);
    }
  }

  public void SaveChanges()
  {
    try
    {
      _context.SaveChanges();
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException("Error saving changes to the database.", dbEx);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException("Error saving changes to the database.", odEx);
    }
  }

  public List<Project> GetAllEntities()
  {
    try
    {
      return _context.Projects
          .Include(p => p.Publications)
          .Include(p => p.Participants)
          .Include(p => p.ActivityResources)
          .ToList();
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException("Error getting all projects.", odEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException("Error getting all projects.", dbEx);
    }
  }
}