namespace Rubns.Core.Ports.Login
{
    public interface ILogInRepository
    {

        Task<UserDTO> GetUserByEmail(string email);
    }
}
