namespace EcoScrapbookingAPI.Business.DTOs.SustainableActivityDTOs;
using System.ComponentModel.DataAnnotations;

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

  public SustainableActivityUpdateDTO(string title, string description, int? maxParticipants, DateTime startDate, DateTime finishDate, bool isActive, decimal greenPointsValue, string homeImageUrl, string nameCollaborator, int addressId)
  {
    Title = title;
    Description = description;
    MaxParticipants = maxParticipants;
    StartDate = startDate;
    FinishDate = finishDate;
    IsActive = isActive;
    GreenPointsValue = greenPointsValue;
    HomeImageUrl = homeImageUrl;
    NameCollaborator = nameCollaborator;
    AddressId = addressId;
  }
}
