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
        return Unauthorized("Invalid user name or password");
      }
    }
    catch (Exception ex)
    {
      return BadRequest($"Error logging in: {ex.Message}");
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
    catch (Exception ex)
    {
      return BadRequest($"Error registering user: {ex.Message}");
    }
  }
}