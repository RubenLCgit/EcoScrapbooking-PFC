using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.ToolDTOs;

public class ToolUpdateDTO
{
  [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
  public string? Name { get; set; }
  [MinLength(3, ErrorMessage = "Type must be at least 3 characters long.")]
  public string? Type { get; set; }
  [MinLength(2, ErrorMessage = "Brand must be at least 2 characters long.")]
  public string? Brand { get; set; }
  [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 1.")]
  public int? Quantity { get; set; }
  [MinLength(10, ErrorMessage = "Description must be at least 10 characters long.")]
  public string? Description { get; set; }
  public int? OwnerUserId { get; set; }
  [MinLength(4, ErrorMessage = "Condition must be at least 4 characters long.")]
  public string? Condition { get; set; }
  public bool? Warranty { get; set; }
  [Url(ErrorMessage = "Invalid URL.")]
  public string? ImageResourceUrl { get; set; }
  public int? TransactionId { get; set; }

  public ToolUpdateDTO() { }

  public ToolUpdateDTO(Tool tool)
  {
    Name = tool.Name;
    Type = tool.Type;
    Brand = tool.Brand;
    Quantity = tool.Quantity;
    Description = tool.Description;
    OwnerUserId = tool.OwnerUserId;
    Condition = tool.Condition;
    Warranty = tool.Warranty;
    ImageResourceUrl = tool.ImageResourceUrl;
    TransactionId = tool.TransactionId;
  }
}