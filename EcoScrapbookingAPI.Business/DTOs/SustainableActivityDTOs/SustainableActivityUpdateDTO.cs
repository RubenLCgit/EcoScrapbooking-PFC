using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.SustainableActivityDTOs;

public class SustainableActivityUpdateDTO
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
  [MinLength(3, ErrorMessage = "Name collaborator must be at least 3 characters long.")]
  public string? NameCollaborator { get; set; }
  public int? AddressId { get; set; }

  public SustainableActivityUpdateDTO() { }

  public SustainableActivityUpdateDTO(SustainableActivity sustainableActivity)
  {
    Title = sustainableActivity.Title;
    Description = sustainableActivity.Description;
    MaxParticipants = sustainableActivity.MaxParticipants;
    StartDate = sustainableActivity.StartDate;
    FinishDate = sustainableActivity.FinishDate;
    IsActive = sustainableActivity.IsActive;
    GreenPointsValue = sustainableActivity.GreenPointsValue;
    HomeImageUrl = sustainableActivity.HomeImageUrl;
    NameCollaborator = sustainableActivity.NameCollaborator;
    AddressId = sustainableActivity.AddressId;
  }
}
