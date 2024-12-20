using EcoScrapbookingAPI.Business.DTOs.ProjectDTOs;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.SustainableActivityDTOs;

public class SustainableActivityGetDTO
{ 
  public int ActivityId { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public int? MaxParticipants { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime FinishDate { get; set; }
  public bool IsActive { get; set; }
  public decimal GreenPointsValue { get; set; }
  public string HomeImageUrl { get; set; }
  public string NameCollaborator { get; set; }
  public int? AddressId { get; set; }
  public int CreatorUserId { get; set; }
  public string ActivityType { get; private set; }
  public List<int> PublicationsIds { get; set; }
  public List<int> ParticipantsIds { get; set; }
  public List<ProjectResourceDTO> SustainableActivityResources { get; set; }

  public SustainableActivityGetDTO() { }

  public SustainableActivityGetDTO(SustainableActivity sustainableActivity)
  {
    ActivityId = sustainableActivity.ActivityId;
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
    CreatorUserId = sustainableActivity.CreatorUserId;
    ActivityType = sustainableActivity.ActivityType;

    if (sustainableActivity.Publications != null)
    {
      PublicationsIds = sustainableActivity.Publications.Select(p => p.PublicationId).ToList();
    }
    if (sustainableActivity.Participants != null)
    {
      ParticipantsIds = sustainableActivity.Participants.Select(u => u.UserId).ToList();
    }
    if (sustainableActivity.ActivityResources != null)
    {
      SustainableActivityResources = sustainableActivity.ActivityResources.Select(r => new ProjectResourceDTO(r.ResourceId, r.ResourceType)).ToList();
    }
  }
}
