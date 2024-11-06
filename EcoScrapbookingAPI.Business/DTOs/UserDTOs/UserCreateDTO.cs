using EcoScrapbookingAPI.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EcoScrapbookingAPI.Business.DTOs.UserDTOs;

public class UserCreateDTO
{
  [Required]
  [MinLength(3, ErrorMessage = "Nickname must be at least 3 characters long.")]
  public string Nickname { get; set; }
  [Required]
  [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
  public string Password { get; set; }
  [Required]
  [EmailAddress(ErrorMessage = "Invalid email address.")]
  public string Email { get; set; }
  [Required]
  [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
  public string Name { get; set; }
  [Required]
  [MinLength(3, ErrorMessage = "Lastname must be at least 3 characters long.")]
  public string Lastname { get; set; }
  [Required]
  [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Select a valid gender.")]
  public string Gender { get; set; }
  [Required]
  [Range(typeof(DateTime), "1/1/1900", "1/1/2024", ErrorMessage = "Birthdate must be between {1} and {2}.")]
  public DateTime BirthDate { get; set; }
  [Required]
  [Url(ErrorMessage = "Invalid URL.")]
  public string AvatarImageUrl { get; set; }

  public UserCreateDTO() { }

  public UserCreateDTO(User user)
  {
    Nickname = user.Nickname;
    Password = user.Password;
    Email = user.Email;
    Name = user.Name;
    Lastname = user.Lastname;
    Gender = user.Gender;
    BirthDate = user.BirthDate;
    AvatarImageUrl = user.AvatarImageUrl;
  }
}