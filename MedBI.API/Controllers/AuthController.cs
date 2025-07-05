using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedBI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        // ✅ REGISTER ENDPOINT
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) ||
                string.IsNullOrEmpty(request.Password) ||
                string.IsNullOrEmpty(request.Role))
            {
                return BadRequest(new { Message = "Email, Password, and Role are required." });
            }

            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return BadRequest(new { Message = "A user with this email already exists." });
            }

            var user = new IdentityUser
            {
                UserName = request.Username ?? request.Email,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    Message = string.Join(", ", result.Errors.Select(e => e.Description))
                });
            }

            if (!await _roleManager.RoleExistsAsync(request.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole(request.Role));
            }

            await _userManager.AddToRoleAsync(user, request.Role);

            return Ok(new
            {
                Message = "User registered successfully.",
                user.Email,
                user.UserName,
                Role = request.Role
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.UsernameOrEmail) || string.IsNullOrEmpty(request.Password))
                {
                    return BadRequest(new { Message = "Username/Email and Password are required." });
                }

                IdentityUser? user = await _userManager.FindByNameAsync(request.UsernameOrEmail);

                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
                }

                if (user == null)
                {
                    return Unauthorized(new { Message = "Invalid credentials." });
                }

                var validPassword = await _userManager.CheckPasswordAsync(user, request.Password);
                if (!validPassword)
                {
                    return Unauthorized(new { Message = "Invalid credentials." });
                }

                var roles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName ?? ""),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var role in roles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var jwtKey = _configuration["JwtSettings:Key"];
                if (string.IsNullOrEmpty(jwtKey))
                {
                    return StatusCode(500, "JWT key missing in configuration.");
                }

                if (jwtKey.Length < 32)
                {
                    return StatusCode(500, "JWT key is too short. It must be at least 256 bits (32 bytes).");
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JwtSettings:Issuer"],
                    audience: _configuration["JwtSettings:Audience"],
                    expires: DateTime.Now.AddHours(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                var apiLogin = new
                {
                    Email = request.UsernameOrEmail,
                    Password = request.Password
                };

                return Ok(new LoginResponse
                {
                    
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                  
                    Expiration = token.ValidTo
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Exception: {ex.Message}\n{ex.StackTrace}");
            }
        }

    }

    public class RegisterRequest
    {
        public string? Username { get; set; }
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role { get; set; } = "";
    }

    public class LoginRequest
    {
        public string UsernameOrEmail { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role { get; set; } = "";
    }

    public class LoginResponse
    {
        public string Token { get; set; } = "";
        public DateTime Expiration { get; set; }
    }
}
