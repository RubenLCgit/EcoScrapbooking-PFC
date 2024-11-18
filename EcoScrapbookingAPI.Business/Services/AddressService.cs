using EcoScrapbookingAPI.Business.DTOs.AddressDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Services;

public class AddressService : IAddressService
{
  private readonly IRepositoryGeneric<Address> _addressRepository;
  private readonly IRepositoryGeneric<SustainableActivity> _sustainableActivityRepository;

  public AddressService(IRepositoryGeneric<Address> addressRepository, IRepositoryGeneric<SustainableActivity> sustainableActivityRepository)
  {
    _addressRepository = addressRepository;
    _sustainableActivityRepository = sustainableActivityRepository;
  }

  public Address CreateAddress(AddressCreateDTO addressCreateDTO, int? userId, int? sustainableActivityId)
  {
    if (userId == null && sustainableActivityId == null) throw new Exception("User ID or Sustainable Activity ID must be provided.");
    var newAddress = _addressRepository.GetAllEntities().FirstOrDefault(a =>
      a.Street == addressCreateDTO.Street &&
      a.Number == addressCreateDTO.Number &&
      a.City == addressCreateDTO.City &&
      a.State == addressCreateDTO.State &&
      a.Country == addressCreateDTO.Country &&
      a.ZipCode == addressCreateDTO.ZipCode &&
      a.Description == addressCreateDTO.Description &&
      a.ContactPhone == addressCreateDTO.ContactPhone
    );
    if (newAddress != null && sustainableActivityId != null) {
      var sustainableActivity = _sustainableActivityRepository.GetByIdEntity(sustainableActivityId.Value);
      if (sustainableActivity != null && !newAddress.SustainableActivities.Contains(sustainableActivity))
      {
        newAddress.SustainableActivities.Add(sustainableActivity);
        _addressRepository.UpdateEntity(newAddress);
        _addressRepository.SaveChanges();
        return newAddress;
      }
      else
      {
        throw new Exception("Address already exists with the same sustainable activity or the sustainable activity does not exist.");
      }
    }
    var address = new Address(addressCreateDTO.Street, addressCreateDTO.Number, addressCreateDTO.City, addressCreateDTO.State, addressCreateDTO.Country, addressCreateDTO.ZipCode, addressCreateDTO.Description, addressCreateDTO.ContactPhone);
    if (sustainableActivityId != null)
    {
      var sustainableActivity = _sustainableActivityRepository.GetByIdEntity(sustainableActivityId.Value);
      if (sustainableActivity != null)
      {
        address.SustainableActivities.Add(sustainableActivity);
      }
    }
    if (userId != null) address.UserId = userId.Value;
    
    _addressRepository.AddEntity(address);
    _addressRepository.SaveChanges();
    return address;
  }

  public void AddSustainableActivityToAddress(int addressId, int sustainableActivityId)
  {
    var address = _addressRepository.GetByIdEntity(addressId);
    if (address == null) throw new Exception("Address not found");
    var sustainableActivity = _sustainableActivityRepository.GetByIdEntity(sustainableActivityId);
    if (sustainableActivity == null)throw new Exception("Sustainable Activity not found");
    address.SustainableActivities.Add(sustainableActivity);
    _addressRepository.UpdateEntity(address);
    _addressRepository.SaveChanges();
  }

  public void UpdateAddress(int addressId, AddressUpdateDTO addressUpdateDTO)
  {
    var address = _addressRepository.GetByIdEntity(addressId);
    if (address == null) throw new ArgumentNullException(nameof(address), "The address to be updated cannot be null.");
    address.UserId = addressUpdateDTO.UserId ?? address.UserId;
    address.Street = addressUpdateDTO.Street ?? address.Street;
    address.Number = addressUpdateDTO.Number ?? address.Number;
    address.City = addressUpdateDTO.City ?? address.City;
    address.State = addressUpdateDTO.State ?? address.State;
    address.Country = addressUpdateDTO.Country ?? address.Country;
    address.ZipCode = addressUpdateDTO.ZipCode ?? address.ZipCode;
    address.Description = addressUpdateDTO.Description ?? address.Description;
    address.ContactPhone = addressUpdateDTO.ContactPhone ?? address.ContactPhone;
    _addressRepository.UpdateEntity(address);
    _addressRepository.SaveChanges();
  }

  public void DeleteAddress(int addressId)
  {
    var address = _addressRepository.GetByIdEntity(addressId);
    if (address == null)throw new ArgumentNullException($"Address with ID {addressId} not found.");
    _addressRepository.DeleteEntity(address);
    _addressRepository.SaveChanges();
  }

  public AddressGetDTO GetAddress(int addressId)
  {
    var address = _addressRepository.GetByIdEntity(addressId);
    if (address == null)throw new ArgumentNullException($"Address with ID {addressId} not found.");
    return new AddressGetDTO(address);
  }

  public List<AddressGetDTO> GetAllAddresses()
  {
    var addresses = _addressRepository.GetAllEntities();
    return MapAddressesToDTOs(addresses);
  }

  private List<AddressGetDTO> MapAddressesToDTOs(List<Address> addresses)
  {
    return addresses.Select(a => new AddressGetDTO(a)).ToList();
  }

}
