using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.TutorialsDTOs;

public class TutorialUpdateDTO
{
  [MinLength(5, ErrorMessage = "Title must be at least 5 characters long.")]
  public string? Title { get; set; }
  [MinLength(10, ErrorMessage = "Description must be at least 10 characters long.")]
  public string? Description { get; set; }
  [Range(0, int.MaxValue, ErrorMessage = "Max participants must be greater than or equal to 0.")]
  public int? MaxParticipants { get; set; }
  public DateTime? StartDate { get; set; }
  public DateTime? FinishDate { get; set; }
  public bool? IsActive { get; set; }
  [Range(0, int.MaxValue, ErrorMessage = "Green points value must be greater than or equal to 0.")]
  public decimal? GreenPointsValue { get; set; }
  [Url(ErrorMessage = "Invalid URL.")]
  public string? HomeImageUrl { get; set; }
  [Range(15, 60, ErrorMessage = "Duration must be between 15 and 60 minutes.")]
  public int? Duration { get; set; }
  public string? VideoUrl { get; set; }

  public TutorialUpdateDTO() { }

  public TutorialUpdateDTO(Tutorial tutorial)
  {
    Title = tutorial.Title;
    Description = tutorial.Description;
    MaxParticipants = tutorial.MaxParticipants;
    StartDate = tutorial.StartDate;
    FinishDate = tutorial.FinishDate;
    IsActive = tutorial.IsActive;
    GreenPointsValue = tutorial.GreenPointsValue;
    HomeImageUrl = tutorial.HomeImageUrl;
    Duration = tutorial.Duration;
    VideoUrl = tutorial.VideoUrl;
  }
}