namespace EcoScrapbookingAPI.Business.DTOs.SustainableActivityDTOs;
using System.ComponentModel.DataAnnotations;

public class SustainableActivityCreateDTO
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
  public string HomeImageUrl { get; set; }
  [Required]
  [MinLength(3, ErrorMessage = "Name collaborator must be at least 3 characters long.")]
  public string NameCollaborator { get; set; }
  [Required]
  public int AddressId { get; set; }
  [Required]
  public int CreatorUserId { get; set; }


  public SustainableActivityCreateDTO() {}

  public SustainableActivityCreateDTO(string title, string description, int maxParticipants, DateTime startDate, DateTime finishDate, decimal greenPointsValue, string homeImageUrl, string nameCollaborator, int addressId, int creatorUserId)
  {
    Title = title;
    Description = description;
    MaxParticipants = maxParticipants;
    StartDate = startDate;
    FinishDate = finishDate;
    GreenPointsValue = greenPointsValue;
    HomeImageUrl = homeImageUrl;
    NameCollaborator = nameCollaborator;
    AddressId = addressId;
    CreatorUserId = creatorUserId;
  }
}
