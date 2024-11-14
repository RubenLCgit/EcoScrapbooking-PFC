using EcoScrapbookingAPI.Business.DTOs.UserDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoScrapbookingAPI.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  private readonly IUserService _userService;

  public UserController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpGet]
  public ActionResult<List<UserGetDTO>> GetAll()
  {
    try
    {
      var users = _userService.GetAllUsers();
      return Ok(users);
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

  [HttpGet("{userId}")]
  public ActionResult<UserGetDTO> Get(int userId)
  {
    try
    {
      return Ok(_userService.GetUser(userId));
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
  public ActionResult<User> Create([FromBody] UserCreateDTO userCreateDTO)
  {
    try
    {
      var user = _userService.CreateUser(userCreateDTO);
      return CreatedAtAction(nameof(Get), new { userId = user.UserId }, user);
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

  [HttpPut("{userId}")]
  public ActionResult Update(int userId, [FromBody] UserUpdateDTO userUpdateDTO)
  {
    try
    {
      _userService.UpdateUser(userId, userUpdateDTO);
      return Ok(userUpdateDTO);
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

  [HttpDelete("{userId}")]
  public ActionResult Delete(int userId)
  {
    try
    {
      _userService.DeleteUser(userId);
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

  [HttpPost("{userId}/activities/{activityId}")]
  public ActionResult AddUserToActivity(int userId, int activityId)
  {
    try
    {
      _userService.AddUserToActivity(userId, activityId);
      return Ok();
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