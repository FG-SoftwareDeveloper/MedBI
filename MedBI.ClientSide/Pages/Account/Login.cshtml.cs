using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;

namespace MedBI.ClientSide.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public LoginInputModel Login { get; set; } = new();

        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostLoginAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var http = _httpClientFactory.CreateClient("MedBI.API");

            var apiLogin = new
            {
                usernameOrEmail = Login.Email,
                password = Login.Password,
                role = Login.Role
            };
            var response = await http.PostAsJsonAsync("api/auth/login", apiLogin);


            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

                if (result is not null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwt = handler.ReadJwtToken(result.Token);

                    var roles = jwt.Claims
                        .Where(c => c.Type == "role" || c.Type == ClaimTypes.Role)
                        .Select(c => c.Value)
                        .ToList();

                    Response.Cookies.Append("jwtToken", result.Token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    });

                    if (roles.Contains("Admin"))
                        return RedirectToPage("/Admin/AdminDashboard");
                    else if (roles.Contains("Analyst"))
                        return RedirectToPage("/Analyst/AnalystDashboard");
                    else if (roles.Contains("Customer"))
                        return RedirectToPage("/Customer/CustomerDashboard");
                    else if (roles.Contains("Doctor"))
                        return RedirectToPage("/Doctor/DoctorDashboard");
                    else if (roles.Contains("IT"))
                        return RedirectToPage("/IT/IT_Dash");
                    else
                        return RedirectToPage("/Index");
                }
            }
            else
            {
                ErrorMessage = "Invalid login attempt.";
            }

            return Page();
        }
    }

    public class LoginInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Username { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";

        [Required]
        public string Role { get; set; } = "";
    }

    public class LoginResponse
    {
        public string Token { get; set; } = "";
    }
}
