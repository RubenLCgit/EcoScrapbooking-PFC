using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.AddressDTOs;

public class AddressGetDTO
{
  public int Id { get; set; }
  public string Street { get; set; }
  public string Number { get; set; }
  public string City { get; set; }
  public string State { get; set; }
  public string Country { get; set; }
  public string ZipCode { get; set; }
  public string Description { get; set; }
  public string ContactPhone { get; set; }

  public List<int> SustainableActivityIds { get; set; }

  public AddressGetDTO() { }

  public AddressGetDTO(Address address)
  {
    Id = address.AddressId;
    Street = address.Street;
    Number = address.Number;
    City = address.City;
    State = address.State;
    Country = address.Country;
    ZipCode = address.ZipCode;
    Description = address.Description;
    ContactPhone = address.ContactPhone;

    if (address.SustainableActivities != null)
    {
      SustainableActivityIds = address.SustainableActivities.Select(sa => sa.ActivityId).ToList();
    }
  }
}