using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Domain.Models.Enums;

namespace EcoScrapbookingAPI.Business.DTOs.TransactionDTOs;

public class TransactionGetDTO
{
  public int TransactionID { get; set; }
  public TransactionType Type { get; set; }
  public TransactionStatus Status { get; set; }
  public DateTime DateInitiated { get; set; }
  public DateTime? DateCompleted { get; set; }
  public int InitiatorUserID { get; set; }
  public int? ReceiverUserID { get; set; }

  public List<int> ResourceIDs { get; set; } = new List<int>();

  public TransactionGetDTO() { }

  public TransactionGetDTO(Transaction transaction)
  {
    TransactionID = transaction.TransactionID;
    Type = transaction.Type;
    Status = transaction.Status;
    DateInitiated = transaction.DateInitiated;
    DateCompleted = transaction.DateCompleted;
    InitiatorUserID = transaction.InitiatorUserID;
    ReceiverUserID = transaction.ReceiverUserID;

    if (transaction.Resources != null)
    {
      ResourceIDs = transaction.Resources.Select(r => r.ResourceId).ToList();
    }
  }
}