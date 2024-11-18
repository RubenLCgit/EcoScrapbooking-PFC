using EcoScrapbookingAPI.Data.Context;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoScrapbookingAPI.Data.Repositories;

public class TutorialRepository : IRepositoryGeneric<Tutorial>
{
  private readonly EcoScrapbookingDBContext _context;

  public TutorialRepository(EcoScrapbookingDBContext context)
  {
    _context = context;
  }

  public void AddEntity(Tutorial tutorial)
  {
    if (tutorial == null) throw new ArgumentNullException(nameof(tutorial), "The tutorial to be added cannot be null.");
    try
    {
      _context.Tutorials.Add(tutorial);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error adding tutorial: {tutorial.Title}", dbEx);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error adding tutorial: {tutorial.Title}", odEx);
    }
  }

  public Tutorial? GetByIdEntity(int tutorialId)
  {
    if (tutorialId <= 0) throw new ArgumentException("Tutorial ID must be greater than zero.", nameof(tutorialId));
    try
    {
      return _context.Tutorials
          .Include(t => t.Publications)
          .Include(t => t.Participants)
          .Include(t => t.ActivityResources)
          .FirstOrDefault(t => t.ActivityId == tutorialId);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error getting tutorial with ID {tutorialId}.", odEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error getting tutorial with ID {tutorialId}.", dbEx);
    }
  }

  public void UpdateEntity(Tutorial tutorial)
  {
    try
    {
      _context.Tutorials.Update(tutorial);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error updating tutorial: {tutorial.Title}", dbEx);
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException($"Error updating tutorial: {tutorial.Title}", ioEx);
    }
  }

  public void DeleteEntity(Tutorial tutorial)
  {
    try
    {
      _context.Tutorials.Remove(tutorial);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error deleting tutorial: {tutorial.Title}", dbEx);
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException($"Error deleting tutorial: {tutorial.Title}", ioEx);
    }
  }

  public List<Tutorial> GetAllEntities()
  {
    try
    {
      return _context.Tutorials
          .Include(t => t.Publications)
          .Include(t => t.Participants)
          .Include(t => t.ActivityResources)
          .ToList();
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException("Error getting all tutorials.", odEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException("Error getting all tutorials.", dbEx);
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
}
