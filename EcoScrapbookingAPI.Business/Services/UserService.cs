using EcoScrapbookingAPI.Business.DTOs.UserDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using BCrypt.Net;

namespace EcoScrapbookingAPI.Business.Services;

public class UserService : IUserService
{
  private readonly IRepositoryGeneric<User> _userRepository;

  public UserService(IRepositoryGeneric<User> userRepository)
  {
    _userRepository = userRepository;
  }

  public User CheckLogin(string userName, string userPassword)
  {
    throw new NotImplementedException();
  }

  public void DeleteUser(int userId)
  {
    var user = _userRepository.GetByIdEntity(userId);
    if (user == null) throw new ArgumentNullException($"User with ID {userId} not found.");
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

  private List<UserGetDTO> MapUsersToDTOs(List<User> users)
  {
    return users.Select(u => new UserGetDTO(u)).ToList();
  }

  private void AssignRole(User user)
  {
    user.Role = user.UserId == 1 ? "Admin" : "User";
  }
}

