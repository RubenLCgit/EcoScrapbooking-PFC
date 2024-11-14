using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoScrapbookingAPI.Domain.Models.Abstracts;

namespace EcoScrapbookingAPI.Domain.Models;

public class SustainableActivity : Activity
{
  [Required]
  public string NameCollaborator { get; set; }
  public int AddressId { get; set; }
  
  [ForeignKey("AddressId")]
  public Address Ubication { get; set; }

  public SustainableActivity() { }

  public SustainableActivity(String title, String description, int maxParticipants, DateTime startDate, DateTime finishDate, decimal greenPointsValue, string homeImageUrl, string nameCollaborator, int creatorUserId, int addressId) : base(title, description, maxParticipants, startDate, finishDate, greenPointsValue, homeImageUrl, creatorUserId)
  {
    NameCollaborator = nameCollaborator;
    AddressId = addressId;
  }
}