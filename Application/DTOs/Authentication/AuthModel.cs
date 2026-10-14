using System.Text.Json.Serialization;

namespace Application.DTOs.Authentication
{
    public class AuthModel
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
        public List<string> Roles { get; set; } = new List<string>();

        [JsonIgnore]
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
