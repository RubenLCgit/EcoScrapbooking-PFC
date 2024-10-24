using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models.Abstracts;

namespace EcoScrapbookingAPI.Domain.Models;

public class Material : Resource
{
  [Required]
  public int duration { get; set; }

  public Material() { }

  public Material(string name, string type, string brand, int quantity, string description, int duration, int ownerUserId) : base(name, type, brand, quantity, description, ownerUserId)
  {
    this.duration = duration;
  }
}