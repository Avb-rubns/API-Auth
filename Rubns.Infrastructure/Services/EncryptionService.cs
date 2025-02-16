namespace Rubns.Infrastructure.Services
{
    internal class EncryptionService : IEncryptionService
    {
        public string GenerateToken(RegisterDTO register, string wordSecret)
        {
            string apiKey = string.Empty;

            string saltSecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(wordSecret));
            byte[] salt = Encoding.UTF8.GetBytes(saltSecret);

            string saltCliente = Convert.ToBase64String(Encoding.UTF8.GetBytes(register.WordSecretUser));
            byte[] saltAux = Encoding.UTF8.GetBytes(saltCliente);

            string nameApp = Convert.ToBase64String(Encoding.UTF8.GetBytes(register.NameApp));
            byte[] Client = Encoding.UTF8.GetBytes(nameApp);

            using (var hmacsha256 = new HMACSHA256(salt))
            {
                byte[] hash = hmacsha256.ComputeHash(Client);

                apiKey = BitConverter.ToString(hash).Replace("-", "").ToLower();

            }

            return apiKey;
        }
    }
}
