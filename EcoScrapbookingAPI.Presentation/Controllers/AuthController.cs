using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EcoScrapbookingAPI.Business.DTOs.UserDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EcoScrapbookingAPI.Presentation.Controllers;

[ApiController]
[Route("[controller]")]

public class AuthController : ControllerBase
{
  private readonly IUserService userService;
  private readonly IConfiguration configuration;

  public AuthController(IUserService _userService, IConfiguration _configuration)
  {
    userService = _userService;
    configuration = _configuration;
  }

  [HttpPost("login")]
  public IActionResult Login([FromBody] UserLoginDTO userLoginDTO)
  {
    try
    {
      var user = userService.LoginUser(userLoginDTO.Email, userLoginDTO.Password);
      if (user != null)
      {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration["JwtSettings:SecretKey"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
          Subject = new ClaimsIdentity(new Claim[]
          {
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
          }),
          Expires = DateTime.UtcNow.AddHours(24),
          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Ok(new
        {
          token = tokenHandler.WriteToken(token),
          expiration = tokenDescriptor.Expires
        });
      }
      else
      {
        return Unauthorized(new { errorCode = "INVALID_CREDENTIALS", message = "Invalid user name or password." });
      }
    }
    catch (ArgumentNullException)
    {
      return NotFound(new { errorCode = "USER_NOT_FOUND", message = "User not found." });
    }
    catch (ArgumentException ex)
    {
      if (ex.Message.Contains("deleted"))
      {
        return BadRequest(new { errorCode = "ACCOUNT_DELETED", message = "This account has been deleted. Please recover your account." });
      }
      if (ex.Message.Contains("banned"))
      {
        return BadRequest(new { errorCode = "ACCOUNT_BANNED", message = "This account has been banned. For more information, please contact us at ecoScrapbookingContact@gmail.com." });
      }
      return BadRequest(new { errorCode = "INVALID_PASSWORD", message = "Invalid password." });
    }
    catch (Exception)
    {
      return StatusCode(500, new { errorCode = "SERVER_ERROR", message = "An unexpected error occurred." });
    }
  }

  [HttpPost("register")]
  public IActionResult Register([FromBody] UserCreateDTO userCreateDTO)
  {
    try
    {
      var user = userService.CreateUser(userCreateDTO);
      return CreatedAtAction("Get", "User", new { userId = user.UserId }, user);
    }
    catch (ArgumentException ex)
    {
      if (ex.Message.Contains("Nickname"))
      {
        return BadRequest(new { errorCode = "NICKNAME_IN_USE", message = "Nickname already in use." });
      }
      return BadRequest(new { errorCode = "EMAIL_IN_USE", message = "Email already in use. Please recover your account or use another email." });
    }
    catch (Exception)
    {
      return StatusCode(500, new { errorCode = "SERVER_ERROR", message = "An unexpected error occurred." });
    }
  }

  [HttpPost("recover")]
  public IActionResult RecoverAccount([FromBody] UserLoginDTO userLoginDTO)
  {
    try
    {
      userService.RecoverAccount(userLoginDTO.Email, userLoginDTO.Password);
      return Ok();
    }
    catch (ArgumentNullException)
    {
      return NotFound(new { errorCode = "USER_NOT_FOUND", message = "User not found." });
    }
    catch (ArgumentException)
    {
      return BadRequest(new { errorCode = "INVALID_PASSWORD", message = "Invalid password." });
    }
    catch (Exception)
    {
      return StatusCode(500, new { errorCode = "SERVER_ERROR", message = "An unexpected error occurred." });
    }
  }
}