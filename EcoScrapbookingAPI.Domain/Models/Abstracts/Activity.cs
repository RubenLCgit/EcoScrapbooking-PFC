using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoScrapbookingAPI.Domain.Models.Abstracts;
public abstract class Activity
{
  [Key]
  public int ActivityId { get; set; }
  [Required]
  public string Title { get; set; }
  [Required]
  public string Description { get; set; }
  public int? MaxParticipants { get; set; }
  [Required]
  public DateTime StartDate { get; set; }
  [Required]
  public DateTime FinishDate { get; set; }
  public bool IsActive { get; set; }
  [Required] 
  public decimal GreenPointsValue { get; set; }
  public string HomeImageUrl { get; set; }
  public ICollection<Publication> Publications { get; set; }
  public ICollection<User> Participants { get; set; }
  public ICollection<Resource> ActivityResources { get; set; }
  public int CreatorUserId { get; set; }

  [ForeignKey("CreatorUserId")] 
  public User CreatorUser { get; set; }

  protected Activity() { }

  protected Activity(string title, string description, int maxParticipants, DateTime startDate, DateTime finishDate, decimal greenPointsValue, int creatorUserId)
  {
    Title = title;
    Description = description;
    MaxParticipants = maxParticipants;
    StartDate = startDate;
    FinishDate = finishDate;
    GreenPointsValue = greenPointsValue;
    CreatorUserId = creatorUserId;
    IsActive = true;
    HomeImageUrl = "https://default-homepage.com";
    Participants = new List<User>();
    ActivityResources = new List<Resource>();
  }
}