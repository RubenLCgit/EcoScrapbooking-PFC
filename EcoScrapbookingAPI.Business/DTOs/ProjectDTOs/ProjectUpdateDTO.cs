namespace EcoScrapbookingAPI.Business.DTOs.ProjectDTOs;
using System.ComponentModel.DataAnnotations;

public class ProjectUpdateDTO
{
  [MinLength(5, ErrorMessage = "Title must have at least 5 characters")]
  public string? Title { get; set; }
  [MinLength(10, ErrorMessage = "Description must have at least 10 characters")]
  public string? Description { get; set; }
  public int? MaxParticipants { get; set; }
  public DateTime? StartDate { get; set; }
  public DateTime? FinishDate { get; set; }
  public bool? IsActive { get; set; }
  [Range(0, int.MaxValue, ErrorMessage = "Green points value must be greater than or equal to 0.")]
  public decimal? GreenPointsValue { get; set; }
  [Url(ErrorMessage = "Invalid URL.")]
  public string? HomeImageUrl { get; set; }
  [MinLength(3, ErrorMessage = "Project type must have at least 3 characters")]
  public string? ProjectType { get; set; }

  public ProjectUpdateDTO() { }

  public ProjectUpdateDTO(string title, string description, int? maxParticipants, DateTime startDate, DateTime finishDate, decimal greenPointsValue, string homeImageUrl, string projectType)
  {
    Title = title;
    Description = description;
    MaxParticipants = maxParticipants;
    StartDate = startDate;
    FinishDate = finishDate;
    GreenPointsValue = greenPointsValue;
    HomeImageUrl = homeImageUrl;
    ProjectType = projectType;
  }
}