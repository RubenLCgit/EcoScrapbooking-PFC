using EcoScrapbookingAPI.Data.Context;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoScrapbookingAPI.Data.Repositories;

public class AddressRepository : IRepositoryGeneric<Address>
{
  private readonly EcoScrapbookingDBContext _context;

  public AddressRepository(EcoScrapbookingDBContext context)
  {
    _context = context;
  }

  public void AddEntity(Address address)
  {
    if (address == null) throw new ArgumentNullException(nameof(address), "The address to be added cannot be null.");
    try
    {
      _context.Addresses.Add(address);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error adding address: {address.Street}", dbEx);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error adding address: {address.Street}", odEx);
    }
  }

  public Address? GetByIdEntity(int addressId)
  {
    if (addressId <= 0) throw new ArgumentException("Address ID must be greater than zero.", nameof(addressId));
    try
    {
      return _context.Addresses.FirstOrDefault(a => a.AddressId == addressId);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error getting address with ID {addressId}.", odEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error getting address with ID {addressId}.", dbEx);
    }
  }

  public void UpdateEntity(Address address)
  {
    try
    {
      _context.Addresses.Update(address);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error updating address: {address.Street}", dbEx);
    }
    catch (InvalidOperationException ioEx)
    {
      throw new InvalidOperationException($"Error updating address: {address.Street}", ioEx);
    }
  }

  public void DeleteEntity(Address address)
  {
    try
    {
      _context.Addresses.Remove(address);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException($"Error deleting address: {address.Street}", dbEx);
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException($"Error deleting address: {address.Street}", odEx);
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

  public List<Address> GetAllEntities()
  {
    try
    {
      return _context.Addresses.ToList();
    }
    catch (ObjectDisposedException odEx)
    {
      throw new ObjectDisposedException("Error getting all addresses.", odEx);
    }
    catch (DbUpdateException dbEx)
    {
      throw new DbUpdateException("Error getting all addresses.", dbEx);
    }
  }

}