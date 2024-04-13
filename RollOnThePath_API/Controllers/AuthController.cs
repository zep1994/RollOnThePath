using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RollOnThePath_API.Data;
using RollOnThePath_API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RollOnThePath_API.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class AuthController(IConfiguration config, ApplicationDbContext dbContext) : ControllerBase
{
    private readonly IConfiguration _config = config;
    private readonly ApplicationDbContext _dbContext = dbContext;

        [HttpPost("signup")]
    public async Task<IActionResult> SignUp(User user)
    {
        // Hash the password before storing
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return Ok(new { message = "User created successfully" });
    }

        [HttpPost("login")]
        public IActionResult Login(UserLogin userLoginRequest)
        {
            var existingUser = _dbContext.Users.SingleOrDefault(u =>
                u.Username == userLoginRequest.Username || u.Email == userLoginRequest.Username);

            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(userLoginRequest.Password, existingUser.Password))
            {
                return Unauthorized(new { message = "Invalid username/email or password" });
            }

            // Generate JWT token
            var token = GenerateJwtToken(existingUser);

            return Ok(new { token });
        }

        private string GenerateJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.FirstName)
        };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
}