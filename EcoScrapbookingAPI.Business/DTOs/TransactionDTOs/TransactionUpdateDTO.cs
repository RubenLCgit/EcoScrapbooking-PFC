using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcoScrapbookingAPI.Business.DTOs.TransactionDTOs
{
    public class TransactionUpdateDTO
    {
      [EnumDataType(typeof(TransactionType))]
      public TransactionType? Type { get; set; }
      public int? ReceiverUserID { get; set; }

      public TransactionUpdateDTO() { }

      public TransactionUpdateDTO(Transaction transaction)
      {
          Type = transaction.Type;
          ReceiverUserID = transaction.ReceiverUserID;
      }
    }
}