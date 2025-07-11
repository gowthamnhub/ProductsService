using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductsService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly string? _secretKey;
    private readonly string? _audience;
    private readonly string? _issuer;

    public AuthController(IConfiguration configuration)
    {
      _secretKey = configuration["Jwt:Key"];
      _issuer = configuration["Jwt:Issuer"];
      _audience = configuration["Jwt:Audience"];
    }
    [HttpPost]
    public IActionResult Login(string userName, string password)
    {
      if (userName.ToLower().Equals("testuser") && password.ToLower().Equals("123456"))
      {
        var token = GenerateJwtToken(userName);
        return Ok(new { Token = token });
      }
      return Unauthorized("Invalid credentials");
    }

    private string GenerateJwtToken(string userName)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      //var secretKey = "secret_key_to_product_service_APIs_12345";
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, userName)
        }),
        Audience = _audience,
        Issuer = _issuer,
        Expires = DateTime.UtcNow.AddMinutes(30),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey)),
          SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }
}
