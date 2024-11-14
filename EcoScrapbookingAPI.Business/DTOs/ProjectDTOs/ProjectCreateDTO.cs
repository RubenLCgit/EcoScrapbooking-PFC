using EcoScrapbookingAPI.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EcoScrapbookingAPI.Business.DTOs.ProjectDTOs;

public class ProjectCreateDTO
{
  [Required]
  [MinLength(5, ErrorMessage = "Title must have at least 5 characters")]
  public string Title { get; set; }
  [Required]
  [MinLength(10, ErrorMessage = "Description must have at least 10 characters")]
  public string Description { get; set; }
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
  [MinLength(3, ErrorMessage = "Project type must have at least 3 characters")]
  public string ProjectType { get; set; }

  public ProjectCreateDTO() { }

  public ProjectCreateDTO(Project project)
  {
    Title = project.Title;
    Description = project.Description;
    MaxParticipants = project.MaxParticipants;
    StartDate = project.StartDate;
    FinishDate = project.FinishDate;
    GreenPointsValue = project.GreenPointsValue;
    HomeImageUrl = project.HomeImageUrl;
    CreatorUserId = project.CreatorUserId;
    ProjectType = project.ProjectType;
  }
}