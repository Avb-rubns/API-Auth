namespace Rubns.Core.Ports.Register
{
    public interface IRegisterRepository
    {
        Task<int> RegisterApplicationAsync(TokenRegisterDTO token);
    }
}
