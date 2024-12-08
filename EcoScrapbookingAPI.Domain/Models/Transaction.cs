using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoScrapbookingAPI.Domain.Models.Abstracts;
using EcoScrapbookingAPI.Domain.Models.Enums;

namespace EcoScrapbookingAPI.Domain.Models;

public class Transaction
{
  [Key]
  public int TransactionID { get; set; }
  public string ArticlesDescription { get; set; }
  public bool IsActive { get; set; }
  [Required]
  public TransactionType Type { get; set; }
  [Required]
  public TransactionStatus Status { get; set; }
  [Required]
  public DateTime DateInitiated { get; set; }
  public DateTime? DateCompleted { get; set; }
  public int InitiatorUserID { get; set; }
  [ForeignKey("InitiatorUserID")]
  public User InitiatorUser { get; set; }
  public int? ReceiverUserID { get; set; }
  [ForeignKey("ReceiverUserID")]
  public User ReceiverUser { get; set; }
  public string ImageTransactionUrl { get; set; }
  public decimal? GreenPointCost { get; set; }
  public ICollection<Resource> Resources { get; set; } = new List<Resource>();
  public Transaction() { }

  public Transaction(string articlesDescription,TransactionType type, int initiatorUserID, int? receiverUserID, string imageTransactionUrl, decimal? greenPointCost)
  {
    ArticlesDescription = articlesDescription;
    Type = type;
    Status = TransactionStatus.Pending;
    DateInitiated = DateTime.Now;
    InitiatorUserID = initiatorUserID;
    ReceiverUserID = receiverUserID;
    IsActive = true;
    ImageTransactionUrl = imageTransactionUrl;
    GreenPointCost = greenPointCost;
  }
}