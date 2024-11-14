using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models.Abstracts;

namespace EcoScrapbookingAPI.Domain.Models;

public class Tool : Resource
{
  [Required]
  public string Condition { get; set; }
  public bool Warranty { get; set; }

  public Tool() { }

  public Tool(string name, string type, string brand, int quantity, string description, int ownerUserId, string imageResourceUrl, int transactionId, string condition, bool warranty) : base(name, type, brand, quantity, description, ownerUserId, imageResourceUrl, transactionId)
  {
    Condition = condition;
    Warranty = warranty;
  }
}