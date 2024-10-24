using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models.Abstracts;

namespace EcoScrapbookingAPI.Domain.Models;
public class Tutorial : Activity
{
  [Required]
  public int Duration { get; set; }

  public Tutorial() { }

  public Tutorial(String title, String description, int maxParticipants, DateTime startDate, DateTime finishDate, decimal greenPointsValue, int duration, int creatorUserId) : base(title, description, maxParticipants, startDate, finishDate, greenPointsValue, creatorUserId)
  {
    Duration = duration;
  }
}
