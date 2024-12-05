using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models.Abstracts;

namespace EcoScrapbookingAPI.Domain.Models;
public class Tutorial : Activity
{
  [Required]
  public int Duration { get; set; }
  public string VideoUrl { get; set; }

  public Tutorial() { }

  public Tutorial(String title, String description, int maxParticipants, DateTime startDate, DateTime finishDate, decimal greenPointsValue, string homeImageUrl,int duration, string videoUrl,int creatorUserId) : base(title, description, maxParticipants, startDate, finishDate, greenPointsValue, homeImageUrl, creatorUserId)
  {
    Duration = duration;
    VideoUrl = videoUrl;
  }
}
