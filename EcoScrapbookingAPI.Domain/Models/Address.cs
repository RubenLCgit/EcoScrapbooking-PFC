using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoScrapbookingAPI.Domain.Models;

public class Address
{
  [Key]
  public int AddressId { get; set; }
  [Required]
  public string Street { get; set; }
  [Required]
  public string Number { get; set; }
  [Required]
  public string City { get; set; }
  [Required]
  public string State { get; set; }
  [Required]
  public string Country { get; set; }
  [Required]
  public string ZipCode { get; set; }
  public string Description { get; set; }
  public string ContactPhone { get; set; }

  //Relaciones

  public int? UserId { get; set; }

  [ForeignKey("UserId")]
  public User User { get; set; }
  public int? SustainableActivityId { get; set; }

  [ForeignKey("SustainableActivityId")]
  public SustainableActivity SustainableActivity { get; set; }


  public Address() { }

  public Address(string street, string number, string city, string state, string country, string zipCode, string description, string contactPhone)
  {
    Street = street;
    Number = number;
    City = city;
    State = state;
    Country = country;
    ZipCode = zipCode;
    Description = description;
    ContactPhone = contactPhone;
  }
}