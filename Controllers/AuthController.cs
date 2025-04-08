/// <summary>
/// API controller for handling authentication (registration and login).
/// </summary>
using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CatalogOnline_API.Models.DTO;

namespace CatalogOnline_API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    /// <summary>
    /// Repository for performing user data operations.
    /// </summary>
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Configuration for accessing application settings.
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthController"/> class with the specified user repository and configuration.
    /// </summary>
    /// <param name="userRepository">The user repository.</param>
    /// <param name="configuration">The application configuration.</param>
    public AuthController(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    /// <summary>
    /// Registers a new user and returns a JWT token.
    /// </summary>
    /// <param name="request">The registration request containing user details.</param>
    /// <returns>An IActionResult containing the JWT token or a BadRequest if the user already exists.</returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
    {
        var existingUser = await _userRepository.GetByNameAsync(request.FirstName, request.LastName);
        if (existingUser != null)
            return BadRequest("User already exists");

        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            PasswordHash = HashPassword(request.Password)
        };

        await _userRepository.AddUserAsync(user);
        var token = GenerateJwtToken(user);
        return Ok(new { token });
    }

    /// <summary>
    /// Authenticates a user and returns a JWT token.
    /// </summary>
    /// <param name="request">The login request containing user credentials.</param>
    /// <returns>An IActionResult containing the JWT token or Unauthorized if credentials are invalid.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
    {
        var user = await _userRepository.GetByNameAsync(request.FirstName, request.LastName);
        if (user == null || !VerifyPassword(request.Password, user.PasswordHash!))
            return Unauthorized("Invalid credentials");

        var token = GenerateJwtToken(user);
        return Ok(new { token });
    }

    /// <summary>
    /// Generates a JWT token for the authenticated user.
    /// </summary>
    /// <param name="user">The authenticated user.</param>
    /// <returns>The generated JWT token as a string.</returns>
    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id!),
            new Claim("FirstName", user.FirstName ?? ""),
            new Claim("LastName", user.LastName ?? "")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /// <summary>
    /// Hashes the provided password using SHA256.
    /// </summary>
    /// <param name="password">The plain text password to hash.</param>
    /// <returns>The hashed password as a Base64 string.</returns>
    private static string HashPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }

    /// <summary>
    /// Verifies whether the provided password matches the hashed password.
    /// </summary>
    /// <param name="password">The plain text password to verify.</param>
    /// <param name="hash">The hashed password for comparison.</param>
    /// <returns>True if the password matches the hash; otherwise, false.</returns>
    private static bool VerifyPassword(string password, string hash)
    {
        return HashPassword(password) == hash;
    }
}
