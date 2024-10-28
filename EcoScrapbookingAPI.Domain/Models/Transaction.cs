using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoScrapbookingAPI.Domain.Models.Abstracts;
using EcoScrapbookingAPI.Domain.Models.Enums;

namespace EcoScrapbookingAPI.Domain.Models;

public class Transaction
{
  [Key]
  public int TransactionID { get; set; }
  [Required]
  public TransactionType Type { get; set; }
  [Required]
  public TransactionStatus Status { get; set; }
  [Required]
  public DateTime DateInitiated { get; set; }
  public DateTime? DateCompleted { get; set; }

  //User that initiated the transaction
  public int InitiatorUserID { get; set; }
  [ForeignKey("InitiatorUserID")]
  public User InitiatorUser { get; set; }

  //User that received the transaction
  public int? ReceiverUserID { get; set; }
  [ForeignKey("ReceiverUserID")]
  public User ReceiverUser { get; set; }
  public ICollection<Resource> Resources { get; set; }
  public Transaction() { }

  public Transaction(TransactionType type, int initiatorUserID, int? receiverUserID)
  {
    Type = type;
    Status = TransactionStatus.Pending;
    DateInitiated = DateTime.Now;
    InitiatorUserID = initiatorUserID;
    ReceiverUserID = receiverUserID;
    Resources = new List<Resource>();
  }
}