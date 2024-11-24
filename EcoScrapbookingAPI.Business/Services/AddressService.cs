using EcoScrapbookingAPI.Business.DTOs.AddressDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Services;

public class AddressService : IAddressService
{
  private readonly IRepositoryGeneric<Address> _addressRepository;
  private readonly IRepositoryGeneric<User> _userRepository;
  private readonly IRepositoryGeneric<SustainableActivity> _sustainableActivityRepository;

  public AddressService(IRepositoryGeneric<Address> addressRepository, IRepositoryGeneric<User> userRepository, IRepositoryGeneric<SustainableActivity> sustainableActivityRepository)
  {
    _addressRepository = addressRepository;
    _userRepository = userRepository;
    _sustainableActivityRepository = sustainableActivityRepository;
  }

  public AddressGetDTO CreateAddress(AddressCreateDTO addressCreateDTO)
  {
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
    if (newAddress != null)
    {
      if (addressCreateDTO.UserId != null)
      {
        if (newAddress.UserId != null) throw new Exception("Address already belongs to a user");
        var user = _userRepository.GetByIdEntity(addressCreateDTO.UserId.Value);
        if (user == null) throw new Exception("User not found");
        newAddress.UserId = user.UserId;
        user.Addresses.Add(newAddress); //! Esto es necesario o ya se agrega al crear la relacion con newAddress.UserId = user.UserId; ?
        _userRepository.UpdateEntity(user);
        _addressRepository.UpdateEntity(newAddress);
        _userRepository.SaveChanges();

        return new AddressGetDTO(newAddress);
      }
    }

    newAddress = new Address
    {
      UserId = addressCreateDTO.UserId,
      Street = addressCreateDTO.Street,
      Number = addressCreateDTO.Number,
      City = addressCreateDTO.City,
      State = addressCreateDTO.State,
      Country = addressCreateDTO.Country,
      ZipCode = addressCreateDTO.ZipCode,
      Description = addressCreateDTO.Description,
      ContactPhone = addressCreateDTO.ContactPhone
    };

    if (addressCreateDTO.UserId != null)
    {
      var user = _userRepository.GetByIdEntity(addressCreateDTO.UserId.Value);
      if (user == null) throw new Exception("User not found");
      user.Addresses.Add(newAddress);  //! Esto es necesario o ya se agrega al crear la relacion con newAddress.UserId = user.UserId; ?
      _userRepository.UpdateEntity(user);
    }

    _addressRepository.AddEntity(newAddress);
    _addressRepository.SaveChanges();
    return new AddressGetDTO(newAddress);
  }

  public void AddAddressToSustainableActivity(int addressId, int sustainableActivityId)
  {
    var address = _addressRepository.GetByIdEntity(addressId);
    if (address == null) throw new Exception("Address not found");
    var sustainableActivity = _sustainableActivityRepository.GetByIdEntity(sustainableActivityId);
    if (sustainableActivity == null) throw new Exception("SustainableActivity not found");
    if (sustainableActivity.Ubication != null) throw new Exception("SustainableActivity already has an address");
    sustainableActivity.Ubication = address;
    address.SustainableActivities.Add(sustainableActivity);
    _sustainableActivityRepository.UpdateEntity(sustainableActivity);
    _addressRepository.UpdateEntity(address);
    _sustainableActivityRepository.SaveChanges();
  }

  public void UpdateAddress(int addressId, AddressUpdateDTO addressUpdateDTO)
  {
    var address = _addressRepository.GetByIdEntity(addressId);
    if (address == null) throw new ArgumentNullException(nameof(address), "The address to be updated cannot be null.");
    address.Street = addressUpdateDTO.Street ?? address.Street;
    address.Number = addressUpdateDTO.Number ?? address.Number;
    address.City = addressUpdateDTO.City ?? address.City;
    address.State = addressUpdateDTO.State ?? address.State;
    address.Country = addressUpdateDTO.Country ?? address.Country;
    address.ZipCode = addressUpdateDTO.ZipCode ?? address.ZipCode;
    address.Description = addressUpdateDTO.Description ?? address.Description;
    address.ContactPhone = addressUpdateDTO.ContactPhone ?? address.ContactPhone;
    
    if(addressUpdateDTO.UserId != null)
    {
      var user = _userRepository.GetByIdEntity(addressUpdateDTO.UserId.Value);
      if (user == null) throw new Exception("User not found");
      address.UserId = user.UserId;

      if (!user.Addresses.Contains(address))
      {
        user.Addresses.Add(address);
        _userRepository.UpdateEntity(user);
        _userRepository.SaveChanges();
      }
    }

    _addressRepository.UpdateEntity(address);
    _addressRepository.SaveChanges();
  }

  public void DeleteAddress(int addressId)
  {
    var address = _addressRepository.GetByIdEntity(addressId);
    if (address == null)throw new ArgumentNullException($"Address with ID {addressId} not found.");
    foreach (var activity in address.SustainableActivities)
    {
      activity.Ubication = null;
      _sustainableActivityRepository.UpdateEntity(activity);
    }
    if (address.UserId != null)
    {
      var user = _userRepository.GetByIdEntity(address.UserId.Value);
      if (user != null)
      {
        user.Addresses.Remove(address);
        _userRepository.UpdateEntity(user);
      }
    }
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
