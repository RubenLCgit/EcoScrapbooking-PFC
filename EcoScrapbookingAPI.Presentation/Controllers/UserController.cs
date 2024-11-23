using System.Security.Claims;
using EcoScrapbookingAPI.Business.DTOs.UserDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Presentation.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoScrapbookingAPI.Presentation.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  private readonly IUserService _userService;

  public UserController(IUserService userService)
  {
    _userService = userService;
  }

  [Authorize (Roles = "Admin")]
  [HttpGet]
  public ActionResult<List<UserGetDTO>> GetAll()
  {
    try
    {
      var users = _userService.GetAllUsers(User.FindFirst(ClaimTypes.Role).Value);
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

  [AllowAnonymous]
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

  [Authorize]
  [HttpPut("{userId}")]
  public ActionResult Update(int userId, [FromBody] UserUpdateDTO userUpdateDTO)
  {
    try
    {
      if(!ControlUserAccess.UserHasAccess(User.FindFirst(ClaimTypes.Role).Value, User.FindFirst(ClaimTypes.NameIdentifier).Value, userId))
      {
        return Unauthorized("You do not have access to update this user.");
      }
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
      if(!ControlUserAccess.UserHasAccess(User.FindFirst(ClaimTypes.Role).Value, User.FindFirst(ClaimTypes.NameIdentifier).Value, userId))
      {
        return Unauthorized("You do not have access to delete this user.");
      }
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

  
  [HttpDelete("{userId}/activities/{activityId}")]
  public ActionResult RemoveUserFromActivity(int userId, int activityId)
  {
    try
    {
      
      _userService.RemoveUserFromActivity(userId, activityId);
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