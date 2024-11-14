using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models.Abstracts;

namespace EcoScrapbookingAPI.Domain.Models;

public class Material : Resource
{
  public Material() { }

  public Material(string name, string type, string brand, int quantity, string description, int ownerUserId, string imageResourceUrl) : base(name, type, brand, quantity, description, ownerUserId, imageResourceUrl) { }
}