using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcoScrapbookingAPI.Business.DTOs.TransactionDTOs;

public class TransactionCreateDTO
{
  [Required]
  [MinLength(5)]
  [MaxLength(100)]
  public string ArticlesDescription { get; set; }
  [Required]
  [EnumDataType(typeof(TransactionType))]
  public TransactionType Type { get; set; }
  [Required]
  public int InitiatorUserID { get; set; }
  public int? ReceiverUserID { get; set; }
  public decimal? GreenPointCost { get; set; }
  public string ImageTransactionUrl { get; set; }

  public TransactionCreateDTO() { }

  public TransactionCreateDTO(Transaction transaction)
  {
    ArticlesDescription = transaction.ArticlesDescription;
    Type = transaction.Type;
    InitiatorUserID = transaction.InitiatorUserID;
    ReceiverUserID = transaction.ReceiverUserID;
    ImageTransactionUrl = transaction.ImageTransactionUrl;
    GreenPointCost = transaction.GreenPointCost;
  }
}