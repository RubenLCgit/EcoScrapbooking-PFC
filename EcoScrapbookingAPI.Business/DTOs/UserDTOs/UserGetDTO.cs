using EcoScrapbookingAPI.Business.DTOs.ActivityDTOs;
using EcoScrapbookingAPI.Business.DTOs.ProjectDTOs;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.UserDTOs;

public class UserGetDTO
{
  public int UserId { get; set; }
  public string Role { get; set; }
  public string Nickname { get; set; }
  public string Email { get; set; }
  public string Name { get; set; }
  public string Lastname { get; set; }
  public string Gender { get; set; }
  public DateTime BirthDate { get; set; }
  public DateTime RegistrationDate { get; set; }
  public bool IsActive { get; set; }
  public bool IsBan { get; set; }
  public decimal GreenPoints { get; set; }
  public string AvatarImageUrl { get; set; }

  public List<int> AddressesIds { get; set; }
  public List<ActivityTypeDTO> ActivitiesParticipatedIds { get; set; }
  public List<ActivityTypeDTO> ActivitiesCreatedIds { get; set; }
  public List<ProjectResourceDTO> ProjectResources { get; set; }
  public List<int> TransactionsInitiatedIds { get; set; }
  public List<int> TransactionsReceivedIds { get; set; }
  public List<int> PostsIds { get; set; }

  public UserGetDTO() { }

  public UserGetDTO(User user)
  {
    UserId = user.UserId;
    Role = user.Role;
    Nickname = user.Nickname;
    Email = user.Email;
    Name = user.Name;
    Lastname = user.Lastname;
    Gender = user.Gender;
    BirthDate = user.BirthDate;
    RegistrationDate = user.RegistrationDate;
    IsActive = user.IsActive;
    IsBan = user.IsBan;
    GreenPoints = user.GreenPoints;
    AvatarImageUrl = user.AvatarImageUrl;

    if (user.Addresses != null)
    {
      AddressesIds = user.Addresses.Select(a => a.AddressId).ToList();
    }
    if (user.ActivitiesParticipated != null)
    {
      ActivitiesParticipatedIds = user.ActivitiesParticipated.Select(a => new ActivityTypeDTO(a.ActivityId, a.ActivityType)).ToList();
    }
    if (user.ActivitiesCreated != null)
    {
      ActivitiesCreatedIds = user.ActivitiesCreated.Select(a => new ActivityTypeDTO(a.ActivityId, a.ActivityType)).ToList();
    }
    if (user.Resources != null)
    {
      ProjectResources = user.Resources.Select(r => new ProjectResourceDTO(r.ResourceId, r.ResourceType)).ToList();
    }
    if (user.TransactionsInitiated != null)
    {
      TransactionsInitiatedIds = user.TransactionsInitiated.Select(t => t.TransactionID).ToList();
    }
    if (user.TransactionsReceived != null)
    {
      TransactionsReceivedIds = user.TransactionsReceived.Select(t => t.TransactionID).ToList();
    }
    if (user.Posts != null)
    {
      PostsIds = user.Posts.Select(p => p.PublicationId).ToList();
    }
  }
}