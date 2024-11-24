using EcoScrapbookingAPI.Business.DTOs.AddressDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoScrapbookingAPI.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
  private readonly IAddressService _addressService;

  public AddressController(IAddressService addressService)
  {
    _addressService = addressService;
  }

  [HttpGet]
  public ActionResult<List<AddressGetDTO>> GetAll()
  {
    try
    {
      var addressesDTO = _addressService.GetAllAddresses();
      return Ok(addressesDTO);
    }
    catch (ArgumentNullException anEx)
    {
      return NotFound(anEx.Message);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpGet("{addressId}")]
  public ActionResult<AddressGetDTO> Get(int addressId)
  {
    try
    {
      var addressDTO = _addressService.GetAddress(addressId);
      return Ok(addressDTO);
    }
    catch (ArgumentNullException anEx)
    {
      return NotFound(anEx.Message);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPost]
  public ActionResult<Address> Create([FromBody] AddressCreateDTO addressCreateDTO)
  {
    try
    {
      var addressDTO = _addressService.CreateAddress(addressCreateDTO);
      return CreatedAtAction(nameof(Get), new { addressId = addressDTO.Id }, addressDTO);
    }
    catch (ArgumentNullException anEx)
    {
      return NotFound(anEx.Message);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPut("{addressId}")]
  public ActionResult Update(int addressId, [FromBody] AddressUpdateDTO addressUpdateDTO)
  {
    try
    {
      _addressService.UpdateAddress(addressId, addressUpdateDTO);
      return NoContent();
    }
    catch (ArgumentNullException anEx)
    {
      return NotFound(anEx.Message);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpDelete("{addressId}")]
  public ActionResult Delete(int addressId)
  {
    try
    {
      _addressService.DeleteAddress(addressId);
      return NoContent();
    }
    catch (ArgumentNullException anEx)
    {
      return NotFound(anEx.Message);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPost("{addressId}/sustainableActivity/{sustainableActivityId}")]
  public ActionResult AddToSustainableActivity(int addressId, int sustainableActivityId)
  {
    try
    {
      _addressService.AddAddressToSustainableActivity(addressId, sustainableActivityId);
      return NoContent();
    }
    catch (ArgumentNullException anEx)
    {
      return NotFound(anEx.Message);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}
