using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.ToolDTOs;

public class ToolGetDTO
{
  public int ResourceId { get; set; }
  public string Name { get; set; }
  public string Type { get; set; }
  public string Brand { get; set; }
  public int Quantity { get; set; }
  public string Description { get; set; }
  public string Condition { get; set; }
  public bool Warranty { get; set; }
  public string ImageResourceUrl { get; set; }
  public int OwnerUserId { get; set; }
  public int? TransactionId { get; set; }
  
  public List<int> ActivitiesIds { get; set; }

  public ToolGetDTO() { }

  public ToolGetDTO(Tool tool)
  {
    ResourceId = tool.ResourceId;
    Name = tool.Name;
    Type = tool.Type;
    Brand = tool.Brand;
    Quantity = tool.Quantity;
    Description = tool.Description;
    Condition = tool.Condition;
    Warranty = tool.Warranty;
    ImageResourceUrl = tool.ImageResourceUrl;
    OwnerUserId = tool.OwnerUserId;
    TransactionId = tool.TransactionId;

    if (tool.Activities != null)
    {
      ActivitiesIds = tool.Activities.Select(a => a.ActivityId).ToList();
    }
  }
}