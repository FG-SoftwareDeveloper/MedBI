using Microsoft.AspNetCore.Mvc;

namespace MedBI.API.DTOs
{
    public class LoginResponse
    {
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public string UserId { get; set; } = "";        // ✅ Add this line
        public List<string> Roles { get; set; } = new();
        public string Token { get; set; } = "";

    }
}
