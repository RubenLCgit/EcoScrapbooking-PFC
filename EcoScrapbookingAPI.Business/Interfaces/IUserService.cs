using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Business.DTOs.UserDTOs;

namespace EcoScrapbookingAPI.Business.Interfaces;

public interface IUserService
{
  User RegisterUser(UserCreateDTO userCreateDTO);
  void UpdateUser(int userId, UserUpdateDTO userCreateUpdateDTO);
  void DeleteUser(int userId);
  List<UserGetDTO> GetAllUsers();
  UserGetDTO GetUser(int userId);
  User CheckLogin(string userName, string userPassword);
}