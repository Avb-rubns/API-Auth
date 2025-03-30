using Rubns.Core.DTOs.LogIn;

namespace Rubns.Core.Ports.Login
{
    public interface ILogOutPort
    {
        Task<bool> LogOut(RefreshTokenRequestDTO token);
    }
}
