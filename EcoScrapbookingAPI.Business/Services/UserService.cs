using EcoScrapbookingAPI.Business.DTOs.UserDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using BCrypt.Net;

namespace EcoScrapbookingAPI.Business.Services;

public class UserService : IUserService
{
  private readonly IRepositoryGeneric<User> _userRepository;
  private readonly IRepositoryGeneric<Project> _projectRepository;
  private readonly IRepositoryGeneric<Tutorial> _tutorialRepository;
  private readonly IRepositoryGeneric<SustainableActivity> _sustainableActivityRepository;

  public UserService(IRepositoryGeneric<User> userRepository, IRepositoryGeneric<Project> projectRepository, IRepositoryGeneric<Tutorial> tutorialRepository, IRepositoryGeneric<SustainableActivity> sustainableActivityRepository)
  {
    _userRepository = userRepository;
    _projectRepository = projectRepository;
    _tutorialRepository = tutorialRepository;
    _sustainableActivityRepository = sustainableActivityRepository;
  }

  public User LoginUser(string userEmail, string userPassword)
  {
    var user = _userRepository.GetAllEntities().FirstOrDefault(u => u.Email == userEmail);
    if (user == null) throw new ArgumentNullException("User not found.");
    if (!BCrypt.Net.BCrypt.Verify(userPassword, user.Password)) throw new ArgumentException("Invalid password.");
    return user;
  }

  public void DeleteUser(int userId)
  {
    var user = _userRepository.GetByIdEntity(userId);
    if (user == null) throw new ArgumentNullException($"User with ID {userId} not found.");
    var activities = user.ActivitiesParticipated;
    foreach (var activity in activities)
    {
      activity.Participants.Remove(user);
    }
    _userRepository.DeleteEntity(user);
    _userRepository.SaveChanges();
  }

  public List<UserGetDTO> GetAllUsers()
  {
    var users = _userRepository.GetAllEntities();
    return MapUsersToDTOs(users);
  }

  public UserGetDTO GetUser(int userId)
  {
    var user = _userRepository.GetByIdEntity(userId);
    if (user == null) throw new ArgumentNullException($"User with ID {userId} not found.");
    return new UserGetDTO(user);
  }

  public User CreateUser(UserCreateDTO userCreateDTO)
  {
    var passwordHashed = BCrypt.Net.BCrypt.HashPassword(userCreateDTO.Password);
    User user = new User( userCreateDTO.Name, userCreateDTO.Lastname, userCreateDTO.Nickname ,userCreateDTO.Email, passwordHashed, userCreateDTO.Gender, userCreateDTO.BirthDate, userCreateDTO.AvatarImageUrl);
    var users = _userRepository.GetAllEntities();
    if(users.Any(u => u.Nickname == user.Nickname || u.Email == user.Email)) throw new ArgumentException("User already exists.");
    AssignRole(user);
    _userRepository.AddEntity(user);
    _userRepository.SaveChanges();
    return user;
  }

  public void UpdateUser(int userId, UserUpdateDTO userUpdateDTO)
  {
    var user = _userRepository.GetByIdEntity(userId);
    if (user == null) throw new ArgumentNullException($"User with ID {userId} not found.");
    user.Name = userUpdateDTO.Name ?? user.Name;
    user.Lastname = userUpdateDTO.Lastname ?? user.Lastname;
    user.Nickname = userUpdateDTO.Nickname ?? user.Nickname;
    user.Email = userUpdateDTO.Email ?? user.Email;
    user.Password = userUpdateDTO.Password != null ? BCrypt.Net.BCrypt.HashPassword(userUpdateDTO.Password) : user.Password;
    user.Gender = userUpdateDTO.Gender ?? user.Gender;
    user.BirthDate = userUpdateDTO.BirthDate ?? user.BirthDate;
    user.AvatarImageUrl = userUpdateDTO.AvatarImageUrl ?? user.AvatarImageUrl;
    _userRepository.UpdateEntity(user);
    _userRepository.SaveChanges();
  }

  public void AddUserToActivity(int userId, int activityId)
  {
    var user = _userRepository.GetByIdEntity(userId);
    if (user == null) throw new ArgumentNullException($"User with ID {userId} not found.");

    var project = _projectRepository.GetByIdEntity(activityId);
    if (project != null)
    {
      user.ActivitiesParticipated.Add(project);
      project.Participants.Add(user);
      _projectRepository.UpdateEntity(project);
    }
    else
    {
      var tutorial = _tutorialRepository.GetByIdEntity(activityId);
      if (tutorial != null)
      {
        user.ActivitiesParticipated.Add(tutorial);
        tutorial.Participants.Add(user);
        _tutorialRepository.UpdateEntity(tutorial);
      }
      else
      {
        var sustainableActivity = _sustainableActivityRepository.GetByIdEntity(activityId);
        if (sustainableActivity != null)
        {
          user.ActivitiesParticipated.Add(sustainableActivity);
          sustainableActivity.Participants.Add(user);
          _sustainableActivityRepository.UpdateEntity(sustainableActivity);
        }
        else
        {
          throw new ArgumentNullException($"Activity with ID {activityId} not found.");
        }
      }
    }
    _userRepository.UpdateEntity(user);
    _userRepository.SaveChanges();
  }

  public void RemoveUserFromActivity(int userId, int activityId)
  {
    var user = _userRepository.GetByIdEntity(userId);
    if (user == null) throw new ArgumentNullException($"User with ID {userId} not found.");

    var project = _projectRepository.GetByIdEntity(activityId);
    if (project != null)
    {
      user.ActivitiesParticipated.Remove(project);
      project.Participants.Remove(user);
      _projectRepository.UpdateEntity(project);
    }
    else
    {
      var tutorial = _tutorialRepository.GetByIdEntity(activityId);
      if (tutorial != null)
      {
        user.ActivitiesParticipated.Remove(tutorial);
        tutorial.Participants.Remove(user);
        _tutorialRepository.UpdateEntity(tutorial);
      }
      else
      {
        var sustainableActivity = _sustainableActivityRepository.GetByIdEntity(activityId);
        if (sustainableActivity != null)
        {
          user.ActivitiesParticipated.Remove(sustainableActivity);
          sustainableActivity.Participants.Remove(user);
          _sustainableActivityRepository.UpdateEntity(sustainableActivity);
        }
        else
        {
          throw new ArgumentNullException($"Activity with ID {activityId} not found.");
        }
      }
    }
    _userRepository.UpdateEntity(user);
    _userRepository.SaveChanges();
  }

  private List<UserGetDTO> MapUsersToDTOs(List<User> users)
  {
    return users.Select(u => new UserGetDTO(u)).ToList();
  }

  private void AssignRole(User user)
  {
    user.Role = user.UserId == 1 ? "Admin" : "User";
  }
}

