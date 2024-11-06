using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using EcoScrapbookingAPI.Data.Context;

namespace EcoScrapbookingAPI.Data.Repositories;

public class UserRepository : IRepositoryGeneric<User>
{
  private readonly EcoScrapbookingDBContext _context;

  public UserRepository(EcoScrapbookingDBContext context)
  {
    _context = context;
  }

  public void AddEntity(User user)
  {
    if (user == null) throw new ArgumentNullException(nameof(user), "The user to be added cannot be null.");
    try
    {
      _context.Users.Add(user);
      _context.SaveChanges();
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error adding user: {user.Name}", dbEx);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error adding user: {user.Name}", odEx);
    }
  }

  public User? GetByIdEntity(int userId)
  {
    if (userId <= 0) throw new ArgumentException("User ID must be greater than zero.", nameof(userId));
    try
    {
      return _context.Users.FirstOrDefault(u => u.UserId == userId);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error getting user with ID {userId}.", odEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error getting user with ID {userId}.", dbEx);
    }
  }

  public void UpdateEntity(User user)
  {
    try
    {
      _context.Users.Update(user);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error updating user: {user.Name}", dbEx);
    }
    catch (InvalidOperationException ioEx)
    {

      throw new InvalidOperationException($"Error updating user: {user.Name}", ioEx);
    }
  }

  public void DeleteEntity(User user)
  {
    try
    {
      _context.Users.Remove(user);
      _context.SaveChanges();
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error deleting user: {user.Name}", dbEx);
    
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException($"Error deleting user: {user.Name}", ioEx);
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
      throw new DbUpdateException($"Error saving changes.", dbEx);
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException($"Error saving changes.", ioEx);
    }
  }

  public List<User> GetAllEntities()
  {
    try
    {
      return _context.Users.ToList();
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException("Error getting all users.", ioEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException("Error getting all users.", dbEx);
    }
    catch (Exception ex)
    {
      throw new Exception("Error getting all users.", ex);
    }
  }
}

//Guardar Cambios en una Capa Superior (Servicio o Controlador) llamando al método SaveChanges()