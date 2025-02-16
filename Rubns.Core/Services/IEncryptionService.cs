namespace Rubns.Core.Services
{
    public interface IEncryptionService
    {
        string GenerateToken(RegisterDTO register,string wordSecret);
    }
}
