using EcoScrapbookingAPI.Data.Context;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoScrapbookingAPI.Data.Repositories;

public class PublicationRepository : IRepositoryGeneric<Publication>
{
  private readonly EcoScrapbookingDBContext _context;

  public PublicationRepository(EcoScrapbookingDBContext context)
  {
    _context = context;
  }

  public void AddEntity(Publication publication)
  {
    if (publication == null) throw new ArgumentNullException(nameof(publication), "The publication to be added cannot be null.");
    try
    {
      _context.Publications.Add(publication);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error adding publication: {publication.Title}", dbEx);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error adding publication: {publication.Title}", odEx);
    }
  }

  public Publication? GetByIdEntity(int publicationId)
  {
    if (publicationId <= 0) throw new ArgumentException("Publication ID must be greater than zero.", nameof(publicationId));
    try
    {
      return _context.Publications
        .Include(p => p.Replies)
        .FirstOrDefault(p => p.PublicationId == publicationId);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error getting publication with ID {publicationId}.", odEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error getting publication with ID {publicationId}.", dbEx);
    }
  }

  public void UpdateEntity(Publication publication)
  {
    try
    {
      _context.Publications.Update(publication);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error updating publication: {publication.Title}", dbEx);
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException($"Error updating publication: {publication.Title}", ioEx);
    }
  }

  public void DeleteEntity(Publication publication)
  {
    try
    {
      _context.Publications.Remove(publication);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error deleting publication: {publication.Title}", dbEx);
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException($"Error deleting publication: {publication.Title}", ioEx);
    }
  }

  public List<Publication> GetAllEntities()
  {
    try
    {
      return _context.Publications
        .Include(p => p.Replies)
        .ToList();
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException("Error getting all publications.", odEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException("Error getting all publications.", dbEx);
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