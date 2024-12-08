using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.UserDTOs
{
    public class UserLoginDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        public UserLoginDTO() { }

        public UserLoginDTO(User user)
        {
          Email = user.Email;
          Password = user.Password;
        }
    }
}