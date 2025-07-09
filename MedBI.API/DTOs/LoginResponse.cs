using Microsoft.AspNetCore.Mvc;

namespace MedBI.API.DTOs
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public string UserName { get; set; }
    }
}
