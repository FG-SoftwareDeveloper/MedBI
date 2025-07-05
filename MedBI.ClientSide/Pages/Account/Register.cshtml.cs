using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MedBI.ClientSide.Models;

namespace MedBI.ClientSide.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public RegisterInputModel Register { get; set; } = new();

        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var http = _httpClientFactory.CreateClient("MedBI.API");

            var response = await http.PostAsJsonAsync("api/auth/register", Register);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Account/Login");
            }
            else
            {
                ErrorMessage = "Registration failed. Please try again.";
                return Page();
            }
        }
    }
}
