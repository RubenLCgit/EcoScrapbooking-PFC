using EcoScrapbookingAPI.Business.DTOs.ProjectDTOs;
using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Domain.Models.Enums;

namespace EcoScrapbookingAPI.Business.DTOs.TransactionDTOs;

public class TransactionGetDTO
{
  public string ArticlesDescription { get; set; }
  public int TransactionID { get; set; }
  public bool IsActive { get; set; }
  public TransactionType Type { get; set; }
  public TransactionStatus Status { get; set; }
  public DateTime DateInitiated { get; set; }
  public DateTime? DateCompleted { get; set; }
  public int InitiatorUserID { get; set; }
  public int? ReceiverUserID { get; set; }
  public string ImageTransactionUrl { get; set; }

  public List<ProjectResourceDTO> Resources { get; set; } = new List<ProjectResourceDTO>();

  public TransactionGetDTO() { }

  public TransactionGetDTO(Transaction transaction)
  {
    ArticlesDescription = transaction.ArticlesDescription;
    TransactionID = transaction.TransactionID;
    IsActive = transaction.IsActive;
    Type = transaction.Type;
    Status = transaction.Status;
    DateInitiated = transaction.DateInitiated;
    DateCompleted = transaction.DateCompleted;
    InitiatorUserID = transaction.InitiatorUserID;
    ReceiverUserID = transaction.ReceiverUserID;
    ImageTransactionUrl = transaction.ImageTransactionUrl;

    if (transaction.Resources != null)
    {
      Resources = transaction.Resources.Select(r => new ProjectResourceDTO(r.ResourceId, r.ResourceType)).ToList();
    }
  }
}