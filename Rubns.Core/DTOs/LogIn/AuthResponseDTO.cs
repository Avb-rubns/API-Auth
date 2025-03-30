namespace Rubns.Core.DTOs.Login
{
    public class AuthResponseDTO
    {
        public JWT AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
