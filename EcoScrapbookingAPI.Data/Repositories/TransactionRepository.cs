using EcoScrapbookingAPI.Data.Context;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoScrapbookingAPI.Data.Repositories;

public class TransactionRepository : IRepositoryGeneric<Transaction>
{
    private readonly EcoScrapbookingDBContext _context;

    public TransactionRepository(EcoScrapbookingDBContext context)
    {
        _context = context;
    }

    public void AddEntity(Transaction transaction)
    {
        if (transaction == null) throw new ArgumentNullException(nameof(transaction), "The transaction to be added cannot be null.");
        try
        {
            _context.Transactions.Add(transaction);
        }
        catch (DbUpdateException dbEx)
        {
            throw new DbUpdateException($"Error adding transaction: {transaction.TransactionID}", dbEx);
        }
        catch (ObjectDisposedException odEx)
        {
            throw new ObjectDisposedException($"Error adding transaction: {transaction.TransactionID}", odEx);
        }
    }

    public Transaction? GetByIdEntity(int transactionId)
    {
        if (transactionId <= 0) throw new ArgumentException("Transaction ID must be greater than zero.", nameof(transactionId));
        try
        {
            return _context.Transactions
                .Include(t => t.Resources)
                .FirstOrDefault(t => t.TransactionID == transactionId);
        }
        catch (ObjectDisposedException odEx)
        {
            throw new ObjectDisposedException($"Error getting transaction with ID {transactionId}.", odEx);
        }
        catch (DbUpdateException dbEx)
        {
            throw new DbUpdateException($"Error getting transaction with ID {transactionId}.", dbEx);
        }
    }

    public void UpdateEntity(Transaction transaction)
    {
        try
        {
            _context.Transactions.Update(transaction);
        }
        catch (DbUpdateException dbEx)
        {
            throw new DbUpdateException($"Error updating transaction: {transaction.TransactionID}", dbEx);
        }
        catch (InvalidOperationException ioEx)
        {
            throw new InvalidOperationException($"Error updating transaction: {transaction.TransactionID}", ioEx);
        }
    }

    public void DeleteEntity(Transaction transaction)
    {
        try
        {
            _context.Transactions.Remove(transaction);
        }
        catch (DbUpdateException dbEx)
        {
            throw new DbUpdateException($"Error deleting transaction: {transaction.TransactionID}", dbEx);
        }
        catch (InvalidOperationException ioEx)
        {
            throw new InvalidOperationException($"Error deleting transaction: {transaction.TransactionID}", ioEx);
        }
    }

    public List<Transaction> GetAllEntities()
    {
        try
        {
            return _context.Transactions
                .Include(t => t.Resources)
                .ToList();
        }
        catch (ObjectDisposedException odEx)
        {
            throw new ObjectDisposedException("Error getting all transactions.", odEx);
        }
        catch (DbUpdateException dbEx)
        {
            throw new DbUpdateException("Error getting all transactions.", dbEx);
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
            throw new DbUpdateException("Error saving changes to transactions.", dbEx);
        }
        catch (ObjectDisposedException odEx)
        {
            throw new ObjectDisposedException("Error saving changes to transactions.", odEx);
        }
    }
}