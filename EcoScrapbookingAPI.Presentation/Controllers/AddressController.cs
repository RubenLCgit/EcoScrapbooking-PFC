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
      var addresses = _addressService.GetAllAddresses();
      return Ok(addresses);
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
      return Ok(_addressService.GetAddress(addressId));
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
  public ActionResult<Address> Create([FromBody] AddressCreateDTO addressCreateDTO, [FromQuery] int? userId, [FromQuery] int? sustainableActivityId)
  {
    try
    {
      // Crear dirección y asociar con usuario o actividad sostenible si es necesario
      var address = _addressService.CreateAddress(addressCreateDTO, userId, sustainableActivityId);
      return CreatedAtAction(nameof(Get), new { addressId = address.AddressId }, address);
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
}
