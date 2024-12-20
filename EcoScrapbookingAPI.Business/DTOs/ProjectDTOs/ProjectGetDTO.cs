using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.ProjectDTOs;

public class ProjectGetDTO
{
  public int ActivityId { get; set; }
  public DateTime CreatedAt { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public int? MaxParticipants { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime FinishDate { get; set; }
  public bool IsActive { get; set; }
  public decimal GreenPointsValue { get; set; }
  public string HomeImageUrl { get; set; }
  public int CreatorUserId { get; set; }
  public string ProjectType { get; set; }
  public string ActivityType { get; private set; }
  public List<int> PublicationsIds { get; set; }
  public List<int> ParticipantsIds { get; set; }
  public List<ProjectResourceDTO> ProjectResources { get; set; }

  public ProjectGetDTO() { }

  public ProjectGetDTO(Project project)
  {
    ActivityId = project.ActivityId;
    CreatedAt = project.CreatedAt;
    Title = project.Title;
    Description = project.Description;
    MaxParticipants = project.MaxParticipants;
    StartDate = project.StartDate;
    FinishDate = project.FinishDate;
    IsActive = project.IsActive;
    GreenPointsValue = project.GreenPointsValue;
    HomeImageUrl = project.HomeImageUrl;
    CreatorUserId = project.CreatorUserId;
    ProjectType = project.ProjectType;
    ActivityType = project.ActivityType;

    if (project.Publications != null)
    {
      PublicationsIds = project.Publications.Select(p => p.PublicationId).ToList();
    }
    if (project.Participants != null)
    {
      ParticipantsIds = project.Participants.Select(u => u.UserId).ToList();
    }
    if (project.ActivityResources != null)
    {
      ProjectResources = project.ActivityResources.Select(r => new ProjectResourceDTO(r.ResourceId, r.ResourceType)).ToList();
    }
  }
}