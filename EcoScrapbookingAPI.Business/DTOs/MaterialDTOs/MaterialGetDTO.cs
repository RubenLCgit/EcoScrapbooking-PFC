using System.Diagnostics;
using EcoScrapbookingAPI.Business.DTOs.ActivityDTOs;
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
  public bool IsSent { get; set; }
  public int? TransactionId { get; set; }
  public string ResourceType { get; protected set; } = "Material";

  public List<ActivityTypeDTO> ActivitiesIds { get; set; }

  public MaterialGetDTO() { }

  public MaterialGetDTO(Material material)
  {
    ResourceId = material.ResourceId;
    Name = material.Name;
    Type = material.Type;
    Brand = material.Brand;
    Description = material.Description;
    ImageResourceUrl = material.ImageResourceUrl;
    OwnerUserId = material.OwnerUserId;
    TransactionId = material.TransactionId;
    IsSent = material.IsSent;

    if (material.Activities != null)
    {
      ActivitiesIds = material.Activities.Select(a => new ActivityTypeDTO(a.ActivityId, a.ActivityType)).ToList();
    }
  }
}