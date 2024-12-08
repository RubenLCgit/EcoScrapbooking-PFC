using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcoScrapbookingAPI.Business.DTOs.TransactionDTOs
{
    public class TransactionUpdateDTO
    {
      [MinLength(5)]
      [MaxLength(100)]
      public string? ArticlesDescription { get; set; }
      [EnumDataType(typeof(TransactionType))]
      public TransactionType? Type { get; set; }
      public int? ReceiverUserID { get; set; }
      public string? ImageTransactionUrl { get; set; }
      public decimal? GreenPointCost { get; set; }

      public TransactionUpdateDTO() { }

      public TransactionUpdateDTO(Transaction transaction)
      {
          Type = transaction.Type;
          ReceiverUserID = transaction.ReceiverUserID;
          ImageTransactionUrl = transaction.ImageTransactionUrl;
          GreenPointCost = transaction.GreenPointCost;
      }
    }
}