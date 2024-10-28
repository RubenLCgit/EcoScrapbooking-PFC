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

  public ICollection<Address> Addresses { get; set; }
  public ICollection<Activity> ActivitiesParticipated { get; set; }
  public ICollection<Activity> ActivitiesCreated { get; set; }
  public ICollection<Resource> Resources { get; set; }
  public ICollection<Transaction> TransactionsInitiated { get; set; }
  public ICollection<Transaction> TransactionsReceived { get; set; }
  public ICollection<Publication> Posts { get; set; }

  public User() { }
  
  public User(String name, String lastname, String email, String password,  String gender, DateTime birthDate)
  {
    Name = name;
    Lastname = lastname;
    Email = email;
    Password = password;
    Gender = gender;
    BirthDate = birthDate;
    RegistrationDate = DateTime.Now;
    IsActive = true;
    GreenPoints = 0.0m;
    AvatarImageUrl = "https://default-avatar.com";
    Addresses = new List<Address>();
    ActivitiesParticipated = new List<Activity>();
    ActivitiesCreated = new List<Activity>();
    Resources = new List<Resource>();
    TransactionsInitiated = new List<Transaction>();
    TransactionsReceived = new List<Transaction>();
    Posts = new List<Publication>();
  }
   
}
