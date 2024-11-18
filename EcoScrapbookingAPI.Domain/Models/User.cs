using EcoScrapbookingAPI.Domain.Models.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace EcoScrapbookingAPI.Domain.Models;

public class User
{
  [Key]
  public int UserId { get; set; }
  [Required]
  public string Role { get; set; }
  [Required]
  public string Nickname { get; set; }
  [Required]
  public string Password { get; set; }
  [Required]
  [EmailAddress]
  public string Email { get; set; }
  [Required]
  public string Name { get; set; }
  [Required]
  public string Lastname { get; set; }
  [Required]
  public string Gender { get; set; }
  [Required]
  public DateTime BirthDate { get; set; }
  public DateTime RegistrationDate { get; set; }
  public bool IsActive { get; set; }
  public decimal GreenPoints { get; set; }
  public string AvatarImageUrl { get; set; }

  public ICollection<Address> Addresses { get; set; } = new List<Address>();
  public ICollection<Activity> ActivitiesParticipated { get; set; } = new List<Activity>();
  public ICollection<Activity> ActivitiesCreated { get; set; } = new List<Activity>();
  public ICollection<Resource> Resources { get; set; } = new List<Resource>();
  public ICollection<Transaction> TransactionsInitiated { get; set; } = new List<Transaction>();
  public ICollection<Transaction> TransactionsReceived { get; set; } = new List<Transaction>();
  public ICollection<Publication> Posts { get; set; } = new List<Publication>();

  public User() { }
  
  public User(String name, String lastname, String nickname ,String email, String password,  String gender, DateTime birthDate, String avatarImageUrl)
  {
    Name = name;
    Lastname = lastname;
    Nickname = nickname;
    Email = email;
    Password = password;
    Gender = gender;
    BirthDate = birthDate;
    RegistrationDate = DateTime.Now;
    IsActive = true;
    GreenPoints = 0.0m;
    AvatarImageUrl = avatarImageUrl;
  }
   
}
