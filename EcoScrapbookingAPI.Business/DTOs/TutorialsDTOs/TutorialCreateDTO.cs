using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.TutorialsDTOs;

public class TutorialCreateDTO
{
  [Required]
  [MinLength(5, ErrorMessage = "Title must be at least 5 characters long.")]
  public string Title { get; set; }
  [Required]
  [MinLength(10, ErrorMessage = "Description must be at least 10 characters long.")]
  public string Description { get; set; }
  [Range(0, int.MaxValue, ErrorMessage = "Max participants must be greater than or equal to 0.")]
  public int? MaxParticipants { get; set; }
  [Required]
  public DateTime StartDate { get; set; }
  [Required]
  public DateTime FinishDate { get; set; }
  [Required]
  [Range(0, int.MaxValue, ErrorMessage = "Green points value must be greater than or equal to 0.")]
  public decimal GreenPointsValue { get; set; }
  [Required]
  [Url(ErrorMessage = "Invalid URL.")]
  public string? HomeImageUrl { get; set; }
  [Required]
  public int CreatorUserId { get; set; }
  [Required]
  [Range(15, 60, ErrorMessage = "Duration must be between 15 and 60 minutes.")]
  public int Duration { get; set; }
  [Required]
  [Url(ErrorMessage = "Invalid URL.")]
  public string VideoUrl { get; set; }

  public TutorialCreateDTO() { }

  public TutorialCreateDTO(Tutorial tutorial)
  {
    Title = tutorial.Title;
    Description = tutorial.Description;
    MaxParticipants = tutorial.MaxParticipants;
    StartDate = tutorial.StartDate;
    FinishDate = tutorial.FinishDate;
    GreenPointsValue = tutorial.GreenPointsValue;
    HomeImageUrl = tutorial.HomeImageUrl;
    CreatorUserId = tutorial.CreatorUserId;
    Duration = tutorial.Duration;
    VideoUrl = tutorial.VideoUrl;
  }
}