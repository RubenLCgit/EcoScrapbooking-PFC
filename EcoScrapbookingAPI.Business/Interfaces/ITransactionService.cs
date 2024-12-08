using EcoScrapbookingAPI.Business.DTOs.TransactionDTOs;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Interfaces;

public interface ITransactionService
{
  Transaction CreateTransaction(TransactionCreateDTO transactionCreateDTO);
  void UpdateTransaction(int transactionId, TransactionUpdateDTO transactionUpdateDTO);
  void DeleteTransaction(int transactionId);
  List<TransactionGetDTO> GetAllTransactions(string role);
  TransactionGetDTO GetTransaction(int transactionId);
  void AcceptedTransaction(int transactionId, int receiverId);
  void RejectedTransaction(int transactionId);
  void CompleteTransaction(int transactionId);
}