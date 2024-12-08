using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.AddressDTOs;

public class AddressUpdateDTO
{
  public int? UserId { get; set; }
  [MinLength(2, ErrorMessage = "Street must be at least 2 characters long.")]
  public string? Street { get; set; }
  [MinLength(1, ErrorMessage = "Number must be at least 1 character long.")]
  public string? Number { get; set; }
  [MinLength(2, ErrorMessage = "City must be at least 2 characters long.")]
  public string? City { get; set; }
  [MinLength(2, ErrorMessage = "State must be at least 2 characters long.")]
  public string? State { get; set; }
  [MinLength(2, ErrorMessage = "Country must be at least 2 characters long.")]
  public string? Country { get; set; }
  [MinLength(5, ErrorMessage = "ZipCode must be at least 5 characters long.")]
  public string? ZipCode { get; set; }
  [MinLength(5, ErrorMessage = "Description must be at least 5 characters long.")]
  public string? Description { get; set; }
  [MinLength(9, ErrorMessage = "ContactPhone must be at least 9 characters long.")]
  public string? ContactPhone { get; set; }
  public bool? IsMainDeliveryAddress { get; set; }

  public AddressUpdateDTO() { }

  public AddressUpdateDTO(Address address)
  {
    UserId = address.UserId;
    Street = address.Street;
    Number = address.Number;
    City = address.City;
    State = address.State;
    Country = address.Country;
    ZipCode = address.ZipCode;
    Description = address.Description;
    ContactPhone = address.ContactPhone;
    IsMainDeliveryAddress = address.IsMainDeliveryAddress;
  }
}