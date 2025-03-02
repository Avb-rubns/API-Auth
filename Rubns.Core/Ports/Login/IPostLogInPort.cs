namespace Rubns.Core.Ports.Login
{
    public interface IPostLogInPort<T>
    {

        Task<T> LogIn(LoginRequestDTO login);
    }
}
