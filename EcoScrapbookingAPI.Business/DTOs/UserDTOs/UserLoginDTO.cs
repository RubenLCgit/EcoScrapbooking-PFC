using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.UserDTOs
{
    public class UserLoginDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Nickname must be at least 3 characters long.")]
        public string Nickname { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        public UserLoginDTO() { }

        public UserLoginDTO(User user)
        {
          Nickname = user.Nickname;
          Password = user.Password;
        }
    }
}