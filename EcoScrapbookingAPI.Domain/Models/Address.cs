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
  public bool IsMainDeliveryAddress { get; set; }

  public int? UserId { get; set; }

  [ForeignKey("UserId")]
  public User AddressUser { get; set; }
  public ICollection<SustainableActivity> SustainableActivities { get; set; } = new List<SustainableActivity>();


  public Address() { }

  public Address(int? userId ,string street, string number, string city, string state, string country, string zipCode, string description, string contactPhone, bool isMainDeliveryAddress)
  {
    UserId = userId;
    Street = street;
    Number = number;
    City = city;
    State = state;
    Country = country;
    ZipCode = zipCode;
    Description = description;
    ContactPhone = contactPhone;
    IsMainDeliveryAddress = false;
  }

}