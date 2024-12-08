using EcoScrapbookingAPI.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EcoScrapbookingAPI.Business.DTOs.MaterialDTOs;

public class MaterialCreateDTO
{
  [Required]
  [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
  public string Name { get; set; }
  [Required]
  [MinLength(3, ErrorMessage = "Type must be at least 3 characters long.")]
  public string Type { get; set; }
  [Required]
  [MinLength(2, ErrorMessage = "Brand must be at least 2 characters long.")]
  public string Brand { get; set; }
  [Required]
  [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 1.")]
  public int Quantity { get; set; }
  [Required]
  [MinLength(10, ErrorMessage = "Description must be at least 10 characters long.")]
  public string Description { get; set; }
  [Required]
  public int OwnerUserId { get; set; }
  [Required]
  [Url(ErrorMessage = "Invalid URL.")]
  public string? ImageResourceUrl { get; set; }
  public int? TransactionId { get; set; }

  public MaterialCreateDTO() { }

  public MaterialCreateDTO(Material material)
  {
    Name = material.Name;
    Type = material.Type;
    Brand = material.Brand;
    Quantity = material.Quantity;
    Description = material.Description;
    OwnerUserId = material.OwnerUserId;
    ImageResourceUrl = material.ImageResourceUrl;
    TransactionId = material.TransactionId;
  }
}