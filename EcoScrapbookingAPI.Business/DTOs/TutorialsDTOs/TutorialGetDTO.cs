using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.TutorialsDTOs;

public class TutorialGetDTO
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
  public int CreatorUserId { get; set; }
  public int Duration { get; set; }
  public List<int> PublicationsIds { get; set; }
  public List<int> ParticipantsIds { get; set; }
  public List<int> ActivityResourcesIds { get; set; }

  public TutorialGetDTO() { }

  public TutorialGetDTO(Tutorial tutorial)
  {
    ActivityId = tutorial.ActivityId;
    Title = tutorial.Title;
    Description = tutorial.Description;
    MaxParticipants = tutorial.MaxParticipants;
    StartDate = tutorial.StartDate;
    FinishDate = tutorial.FinishDate;
    IsActive = tutorial.IsActive;
    GreenPointsValue = tutorial.GreenPointsValue;
    HomeImageUrl = tutorial.HomeImageUrl;
    CreatorUserId = tutorial.CreatorUserId;
    Duration = tutorial.Duration;

    if (tutorial.Publications != null)
    {
      PublicationsIds = tutorial.Publications.Select(p => p.PublicationId).ToList();
    }
    if (tutorial.Participants != null)
    {
      ParticipantsIds = tutorial.Participants.Select(u => u.UserId).ToList();
    }
    if (tutorial.ActivityResources != null)
    {
      ActivityResourcesIds = tutorial.ActivityResources.Select(r => r.ResourceId).ToList();
    }
  }
}