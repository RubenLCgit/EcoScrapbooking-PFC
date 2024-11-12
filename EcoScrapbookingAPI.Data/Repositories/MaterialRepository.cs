using EcoScrapbookingAPI.Data.Context;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoScrapbookingAPI.Data.Repositories;

public class MaterialRepository : IRepositoryGeneric<Material>
{
  private readonly EcoScrapbookingDBContext _context;

  public MaterialRepository(EcoScrapbookingDBContext context)
  {
    _context = context;
  }

  public void AddEntity(Material material)
  {
    if (material == null) throw new ArgumentNullException(nameof(material), "The material to be added cannot be null.");
    try
    {
      _context.Materials.Add(material);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error adding material: {material.Name}", dbEx);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error adding material: {material.Name}", odEx);
    }
  }

  public Material? GetByIdEntity(int materialId)
  {
    if (materialId <= 0) throw new ArgumentException("Material ID must be greater than zero.", nameof(materialId));
    try
    {
      return _context.Materials.FirstOrDefault(m => m.ResourceId == materialId);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error getting material with ID {materialId}.", odEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error getting material with ID {materialId}.", dbEx);
    }
  }

  public void UpdateEntity(Material material)
  {
    try
    {
      _context.Materials.Update(material);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error updating material: {material.Name}", dbEx);
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException($"Error updating material: {material.Name}", ioEx);
    }
  }

  public void DeleteEntity(Material material)
  {
    try
    {
      _context.Materials.Remove(material);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error deleting material: {material.Name}", dbEx);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error deleting material: {material.Name}", odEx);
    }
  }

  public List<Material> GetAllEntities()
  {
    try
    {
      return _context.Materials.ToList();
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException("Error getting all materials.", odEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException("Error getting all materials.", dbEx);
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