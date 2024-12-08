using EcoScrapbookingAPI.Business.DTOs.AddressDTOs;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Interfaces;

public interface IAddressService
{
  AddressGetDTO CreateAddress(AddressCreateDTO addressCreateDTO);
  void UpdateAddress(int addressId, AddressUpdateDTO addressUpdateDTO);
  void DeleteAddress(int addressId);
  List<AddressGetDTO> GetAllAddresses();
  AddressGetDTO GetAddress(int addressId);
  void AddAddressToSustainableActivity(int addressId, int sustainableActivityId);
}