using EcoScrapbookingAPI.Data.Context;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoScrapbookingAPI.Data.Repositories;

public class SustainableActivityRepository : IRepositoryGeneric<SustainableActivity>
{
  private readonly EcoScrapbookingDBContext _context;

  public SustainableActivityRepository(EcoScrapbookingDBContext context)
  {
    _context = context;
  }

  public void AddEntity(SustainableActivity sustainableActivity)
  {
    if (sustainableActivity == null) throw new ArgumentNullException(nameof(sustainableActivity), "The sustainable activity to be added cannot be null.");
    try
    {
      _context.SustainableActivities.Add(sustainableActivity);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error adding sustainable activity: {sustainableActivity.Title}", dbEx);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error adding sustainable activity: {sustainableActivity.Title}", odEx);
    }
  }

  public SustainableActivity? GetByIdEntity(int sustainableActivityId)
  {
    if (sustainableActivityId <= 0) throw new ArgumentException("Sustainable activity ID must be greater than zero.", nameof(sustainableActivityId));
    try
    {
      return _context.SustainableActivities.FirstOrDefault(sa => sa.ActivityId == sustainableActivityId);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error getting sustainable activity with ID {sustainableActivityId}.", odEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error getting sustainable activity with ID {sustainableActivityId}.", dbEx);
    }
  }

  public void UpdateEntity(SustainableActivity sustainableActivity)
  {
    try
    {
      _context.SustainableActivities.Update(sustainableActivity);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error updating sustainable activity: {sustainableActivity.Title}", dbEx);
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException($"Error updating sustainable activity: {sustainableActivity.Title}", ioEx);
    }
  }

  public void DeleteEntity(SustainableActivity sustainableActivity)
  {
    try
    {
      _context.SustainableActivities.Remove(sustainableActivity);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error deleting sustainable activity: {sustainableActivity.Title}", dbEx);
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException($"Error deleting sustainable activity: {sustainableActivity.Title}", ioEx);
    }
  }

  public List<SustainableActivity> GetAllEntities()
  {
    try
    {
      return _context.SustainableActivities.ToList();
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException("Error getting all sustainable activities.", odEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException("Error getting all sustainable activities.", dbEx);
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
      throw new DbUpdateException("Error saving changes.", dbEx);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException("Error saving changes.", odEx);
    }
  }
}