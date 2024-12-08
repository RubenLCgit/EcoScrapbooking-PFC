using EcoScrapbookingAPI.Domain.Models;
using System.ComponentModel.DataAnnotations;


namespace EcoScrapbookingAPI.Business.DTOs.UserDTOs;

public class UserUpdateDTO
{
  [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
  public string? Name { get; set; }
  [MinLength(3, ErrorMessage = "Lastname must be at least 3 characters long.")]
  public string? Lastname { get; set; }
  [MinLength(2, ErrorMessage = "Nickname must be at least 2 characters long.")]
  public string? Nickname { get; set; }
  [EmailAddress(ErrorMessage = "Invalid email address.")]
  public string? Email { get; set; }
  [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
  public string? Password { get; set; }
  [DataType(DataType.Date)]
  [Range(typeof(DateTime), "1/1/1900", "1/1/2024", ErrorMessage = "Birthdate must be between {1} and {2}.")]
  public DateTime? BirthDate { get; set; }
  public decimal? GreenPoints { get; set; }

  [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Select a valid gender.")]
  public string? Gender { get; set; }
  [Url(ErrorMessage = "Invalid URL.")]
  public string? AvatarImageUrl { get; set; }
  public UserUpdateDTO() { }
  public UserUpdateDTO(User user)
  {
    Name = user.Name;
    Lastname = user.Lastname;
    Nickname = user.Nickname;
    Email = user.Email;
    Password = user.Password;
    BirthDate = user.BirthDate;
    GreenPoints = user.GreenPoints;
    Gender = user.Gender;
    AvatarImageUrl = user.AvatarImageUrl;
  }
}
