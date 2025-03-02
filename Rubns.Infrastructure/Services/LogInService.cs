using System.Text;

namespace Rubns.Infrastructure.Services
{
    internal class LogInService : ILogInService
    {
        private readonly IConfiguration Configuration;

        public LogInService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public JWT CreateJWT(UserDTO user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            string? salt = Configuration["WordSecretJWT"];
            if (string.IsNullOrWhiteSpace(salt))
                throw new InvalidOperationException("JWT secret key is not configured properly.");

            string claims = CreateClaims(user, salt);
            if (string.IsNullOrEmpty(claims))
                throw new Exception("Error generating JWT claims.");

            var expireTime = DateTime.UtcNow.AddHours(10);
            long unixTime = ((DateTimeOffset)expireTime).ToUnixTimeSeconds();

            return new JWT
            {
                AccessToken = claims,
                ExpiresIn = unixTime.ToString(),
                TokenType = "bearer"
            };
        }


        public string CreateClaims(UserDTO user, string salt)
        {
            var payload = new JwtPayload
            {
                { "firstName", user.UserName },
                { "email", user.Email },
                { "iss", "RUBNS-AUTH" },
                { "validAudience", "RUBNS" },
                { "iat", DateTimeOffset.UtcNow.ToUnixTimeSeconds() },
                { "exp", DateTimeOffset.UtcNow.AddHours(10).ToUnixTimeSeconds() },
                { "role", new List<string> { user.Value } },
                { "levelPermission", user.LevelPermission.ToString() },
                { "status", user.Status },
                { "userId", user.UserID }
            };
            if (Configuration["Enviroment"] == "dev")
            {
                IdentityModelEventSource.ShowPII = true;
            }
            var keyBuffer = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(salt));
            var signingCredentials = new SigningCredentials(keyBuffer, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new JwtSecurityToken(new JwtHeader(signingCredentials), payload);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
