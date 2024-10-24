using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoScrapbookingAPI.Domain.Models.Abstracts;

namespace EcoScrapbookingAPI.Domain.Models;

public class Transaction
{
  [Key]
  public int TransactionID { get; set; }
  [Required]
  public int Quantity { get; set; }
  [Required]
  public DateTime Date { get; set; }
  [Required]
  public int OldOwnerUserID { get; set; }

  [ForeignKey("OldOwnerUserID")]
  public User OldOwnerUser { get; set; }
  public int NewOwnerUserID { get; set; }

  [ForeignKey("NewOwnerUserID")]
  public User NewOwnerUser { get; set; }
  public int ResourceID { get; set; }
  
  [ForeignKey("ResourceID")]
  public Resource TransferredResource { get; set; }
  public Transaction() { }

  public Transaction(int quantity, DateTime date, int oldOwnerUserID, int newOwnerUserID, int resourceID)
  {
    Quantity = quantity;
    Date = date;
    OldOwnerUserID = oldOwnerUserID;
    NewOwnerUserID = newOwnerUserID;
    ResourceID = resourceID;
  }
}