using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoScrapbookingAPI.Domain.Models.Abstracts;

public abstract class Resource
{
  [Key]
  public int ResourceId { get; set; }
  [Required]
  public string Name { get; set; }
  [Required]
  public string Type { get; set; }
  [Required]
  public string Brand { get; set; }
  [Required]
  public int Quantity { get; set; }
  [Required]
  public string Description { get; set; }
  public string ImageResourceUrl { get; set; }

  [Required]
  public int OwnerUserId { get; set; }

  [ForeignKey("OwnerUserId")]
  public User OwnerUser { get; set; }

  public ICollection<Activity> Activities { get; set; }

  public int? TransactionId { get; set; }

  [ForeignKey("TransactionId")]
  public Transaction Transaction { get; set; }

  protected Resource() { }

  protected Resource(string name, string type, string brand, int quantity, string description, int ownerUserId)
  {
    Name = name;
    Type = type;
    Brand = brand;
    Quantity = quantity;
    Description = description;
    OwnerUserId = ownerUserId;
    ImageResourceUrl = "https://default-image.com";
    Activities = new List<Activity>();
  }
}