using EcoScrapbookingAPI.Business.DTOs.TransactionDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Domain.Models.Abstracts;
using EcoScrapbookingAPI.Domain.Models.Enums;

namespace EcoScrapbookingAPI.Business.Services;

public class TransactionService : ITransactionService
{
  private readonly IRepositoryGeneric<Transaction> _transactionRepository;
  private readonly IRepositoryGeneric<Tool> _toolRepository;
  private readonly IRepositoryGeneric<Material> _materialRepository;

  public TransactionService(IRepositoryGeneric<Transaction> transactionRepository, IRepositoryGeneric<Tool> toolRepository, IRepositoryGeneric<Material> materialRepository)
  {
      _transactionRepository = transactionRepository;
      _toolRepository = toolRepository;
      _materialRepository = materialRepository;
  }

  public Transaction CreateTransaction(TransactionCreateDTO transactionCreateDTO)
  {
      var transaction = new Transaction(transactionCreateDTO.Type, transactionCreateDTO.InitiatorUserID, transactionCreateDTO.ReceiverUserID);
      _transactionRepository.AddEntity(transaction);
      _transactionRepository.SaveChanges();
      return transaction;
  }

  public void UpdateTransaction(int transactionId, TransactionUpdateDTO transactionUpdateDTO)
  {
      var transaction = _transactionRepository.GetByIdEntity(transactionId);
      if (transaction == null) throw new Exception("Transaction not found");
      transaction.Type = transactionUpdateDTO.Type ?? transaction.Type;
      transaction.ReceiverUserID = transactionUpdateDTO.ReceiverUserID ?? transaction.ReceiverUserID;
      _transactionRepository.UpdateEntity(transaction);
      _transactionRepository.SaveChanges();
  }

  public void DeleteTransaction(int transactionId)
  {
      var transaction = _transactionRepository.GetByIdEntity(transactionId);
      if (transaction == null) throw new Exception("Transaction not found");
      _transactionRepository.DeleteEntity(transaction);
      _transactionRepository.SaveChanges();
  }

  public List<TransactionGetDTO> GetAllTransactions()
  {
      var transactions = _transactionRepository.GetAllEntities();
      return MapTransactionToDTOs(transactions);
  }

  private List<TransactionGetDTO> MapTransactionToDTOs(List<Transaction> transactions)
  {
      return transactions.Select(t => new TransactionGetDTO(t)).ToList();
  }

  public TransactionGetDTO GetTransaction(int transactionId)
  {
      var transaction = _transactionRepository.GetByIdEntity(transactionId);
      if (transaction == null) throw new Exception("Transaction not found");
      return new TransactionGetDTO(transaction);
  }

  public void AcceptedTransaction(int transactionId)
  {
      var transaction = _transactionRepository.GetByIdEntity(transactionId);
      if (transaction == null) throw new Exception("Transaction not found");
      transaction.Status = TransactionStatus.Accepted;
      _transactionRepository.UpdateEntity(transaction);
      _transactionRepository.SaveChanges();
  }

  public void RejectedTransaction(int transactionId)
  {
      var transaction = _transactionRepository.GetByIdEntity(transactionId);
      if (transaction == null) throw new Exception("Transaction not found");
      transaction.Status = TransactionStatus.Rejected;
      transaction.DateCompleted = DateTime.Now;
      _transactionRepository.UpdateEntity(transaction);
      _transactionRepository.SaveChanges();
  }

  public void CompleteTransaction(int transactionId)
  {
    var transaction = _transactionRepository.GetByIdEntity(transactionId);
    if (transaction == null)
      throw new Exception("Transaction not found");

    if (transaction.Status != TransactionStatus.Accepted)
      throw new Exception("Only accepting transactions can be completed.");

    if (!transaction.ReceiverUserID.HasValue)
      throw new Exception("Transaction must have a receiver to complete.");

    foreach (var resource in transaction.Resources)
    {
      if (resource is Tool tool)
      {
        tool.OwnerUserId = transaction.ReceiverUserID.Value;
        _toolRepository.UpdateEntity(tool);
      }
      else if (resource is Material material)
      {
        material.OwnerUserId = transaction.ReceiverUserID.Value;
        _materialRepository.UpdateEntity(material);
      }
      else
      {
        throw new Exception("Unknown resource type");
      }
    }

    transaction.Status = TransactionStatus.Completed;
    transaction.DateCompleted = DateTime.Now;

    _transactionRepository.UpdateEntity(transaction);
    _transactionRepository.SaveChanges();
  }
}