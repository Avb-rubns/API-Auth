namespace Rubns.Core.Ports.Register
{
    public interface IRegisterInputPort
    {
        Task RegisterAppAsync(RegisterDTO registerDTO);
    }
}
