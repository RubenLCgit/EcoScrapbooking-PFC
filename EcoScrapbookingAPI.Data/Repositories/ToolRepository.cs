using EcoScrapbookingAPI.Data.Context;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoScrapbookingAPI.Data.Repositories;

public class ToolRepository : IRepositoryGeneric<Tool>
{
  private readonly EcoScrapbookingDBContext _context;

  public ToolRepository(EcoScrapbookingDBContext context)
  {
    _context = context;
  }

  public void AddEntity(Tool tool)
  {
    if (tool == null) throw new ArgumentNullException(nameof(tool), "The tool to be added cannot be null.");
    try
    {
      _context.Tools.Add(tool);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error adding tool: {tool.Name}", dbEx);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error adding tool: {tool.Name}", odEx);
    }
  }

  public Tool? GetByIdEntity(int toolId)
  {
    if (toolId <= 0) throw new ArgumentException("Tool ID must be greater than zero.", nameof(toolId));
    try
    {
      return _context.Tools
        .Include(t => t.OwnerUser)
        .Include(t => t.Activities)
        .FirstOrDefault(t => t.ResourceId== toolId);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error getting tool with ID {toolId}.", odEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error getting tool with ID {toolId}.", dbEx);
    }
  }

  public void UpdateEntity(Tool tool)
  {
    try
    {
      _context.Tools.Update(tool);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error updating tool: {tool.Name}", dbEx);
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException($"Error updating tool: {tool.Name}", ioEx);
    }
  }

  public void DeleteEntity(Tool tool)
  {
    try
    {
      _context.Tools.Remove(tool);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error deleting tool: {tool.Name}", dbEx);
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException($"Error deleting tool: {tool.Name}", ioEx);
    }
  }

  public List<Tool> GetAllEntities()
  {
    try
    {
      return _context.Tools
        .Include(t => t.OwnerUser)
        .Include(t => t.Activities)
        .ToList();
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException("Error getting all tools.", odEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException("Error getting all tools.", dbEx);
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