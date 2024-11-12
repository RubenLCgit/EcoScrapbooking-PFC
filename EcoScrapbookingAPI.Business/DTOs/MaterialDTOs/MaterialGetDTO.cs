using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.MaterialDTOs;

public class MaterialGetDTO
{
  public int ResourceId { get; set; }
  public string Name { get; set; }
  public string Type { get; set; }
  public string Brand { get; set; }
  public int Quantity { get; set; }
  public string Description { get; set; }
  public string ImageResourceUrl { get; set; }
  public int OwnerUserId { get; set; }
  public int? TransactionId { get; set; }
  
  public List<int> ActivitiesIds { get; set; }

  public MaterialGetDTO() { }

  public MaterialGetDTO(Material material)
  {
    ResourceId = material.ResourceId;
    Name = material.Name;
    Type = material.Type;
    Brand = material.Brand;
    Quantity = material.Quantity;
    Description = material.Description;
    ImageResourceUrl = material.ImageResourceUrl;
    OwnerUserId = material.OwnerUserId;
    TransactionId = material.TransactionId;

    if (material.Activities != null)
    {
      ActivitiesIds = material.Activities.Select(a => a.ActivityId).ToList();
    }
  }
}