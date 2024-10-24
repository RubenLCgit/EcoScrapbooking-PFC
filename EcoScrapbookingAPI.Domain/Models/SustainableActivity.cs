using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models.Abstracts;

namespace EcoScrapbookingAPI.Domain.Models;

public class SustainableActivity : Activity
{
  [Required]
  public string NameCollaborator { get; set; }
  [Required]
  public ICollection<Address> Ubications { get; set; }

  public SustainableActivity() { }

  public SustainableActivity(String title, String description, int maxParticipants, DateTime startDate, DateTime finishDate, decimal greenPointsValue, string nameCollaborator, Address ubication, int creatorUserId) : base(title, description, maxParticipants, startDate, finishDate, greenPointsValue, creatorUserId)
  {
    NameCollaborator = nameCollaborator;
    Ubications = new List<Address>();
  }
}