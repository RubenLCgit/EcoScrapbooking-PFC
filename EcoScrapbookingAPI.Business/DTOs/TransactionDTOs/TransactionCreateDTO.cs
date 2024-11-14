using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcoScrapbookingAPI.Business.DTOs.TransactionDTOs;

public class TransactionCreateDTO
{
  [Required]
  [EnumDataType(typeof(TransactionType))]
  public TransactionType Type { get; set; }
  [Required]
  [EnumDataType(typeof(TransactionStatus))]
  public TransactionStatus Status { get; set; }
  [Required]
  public DateTime DateInitiated { get; set; }
  public DateTime? DateCompleted { get; set; }
  [Required]
  public int InitiatorUserID { get; set; }
  public int? ReceiverUserID { get; set; }

  public TransactionCreateDTO() { }

  public TransactionCreateDTO(Transaction transaction)
  {
    Type = transaction.Type;
    Status = transaction.Status;
    DateInitiated = transaction.DateInitiated;
    DateCompleted = transaction.DateCompleted;
    InitiatorUserID = transaction.InitiatorUserID;
    ReceiverUserID = transaction.ReceiverUserID;
  }
}