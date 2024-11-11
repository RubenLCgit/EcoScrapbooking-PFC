using EcoScrapbookingAPI.Business.DTOs.AddressDTOs;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Interfaces;

public interface IAddressService
{
  Address CreateAddress(AddressCreateDTO addressCreateDTO, int? userId, int? sustainableActivityId);
  void UpdateAddress(int addressId, AddressUpdateDTO addressUpdateDTO);
  void DeleteAddress(int addressId);
  List<AddressGetDTO> GetAllAddresses();
  AddressGetDTO GetAddress(int addressId);
}