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
  public decimal GreenPoints { get; set; }
  public string AvatarImageUrl { get; set; }

  public List<int> AddressesIds { get; set; }
  public List<int> ActivitiesParticipatedIds { get; set; }
  public List<int> ActivitiesCreatedIds { get; set; }
  public List<int> ResourcesIds { get; set; }
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
    GreenPoints = user.GreenPoints;
    AvatarImageUrl = user.AvatarImageUrl;

    if (user.Addresses != null)
    {
      AddressesIds = user.Addresses.Select(a => a.AddressId).ToList();
    }
    if (user.ActivitiesParticipated != null)
    {
      ActivitiesParticipatedIds = user.ActivitiesParticipated.Select(a => a.ActivityId).ToList();
    }
    if (user.ActivitiesCreated != null)
    {
      ActivitiesCreatedIds = user.ActivitiesCreated.Select(a => a.ActivityId).ToList();
    }
    if (user.Resources != null)
    {
      ResourcesIds = user.Resources.Select(r => r.ResourceId).ToList();
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
      PostsIds = user.Posts.Select(p => p.PublicationID).ToList();
    }
  }
}