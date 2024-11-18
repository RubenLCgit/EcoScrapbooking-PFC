using EcoScrapbookingAPI.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EcoScrapbookingAPI.Business.DTOs.AddressDTOs;

public class AddressCreateDTO
{
  [Required]
  [MinLength(2, ErrorMessage = "Street must be at least 2 characters long.")]
  public string Street { get; set; }
  [Required]
  [MinLength(1, ErrorMessage = "Number must be at least 1 character long.")]
  public string Number { get; set; }
  [Required]
  [MinLength(2, ErrorMessage = "City must be at least 2 characters long.")]
  public string City { get; set; }
  [Required]
  [MinLength(2, ErrorMessage = "State must be at least 2 characters long.")]
  public string State { get; set; }
  [Required]
  [MinLength(2, ErrorMessage = "Country must be at least 2 characters long.")]
  public string Country { get; set; }
  [Required]
  [MinLength(5, ErrorMessage = "ZipCode must be at least 5 characters long.")]
  public string ZipCode { get; set; }
  [Required]
  [MinLength(5, ErrorMessage = "Description must be at least 5 characters long.")]
  public string Description { get; set; }
  [Required]
  [MinLength(9, ErrorMessage = "ContactPhone must be at least 9 characters long.")]
  public string ContactPhone { get; set; }

  public int? UserId { get; set; }
  public int? SustainableActivityId { get; set; }

  public AddressCreateDTO() { }

  public AddressCreateDTO(Address address)
  {
    Street = address.Street;
    Number = address.Number;
    City = address.City;
    State = address.State;
    Country = address.Country;
    ZipCode = address.ZipCode;
    Description = address.Description;
    ContactPhone = address.ContactPhone;
  }
}
