namespace Rubns.Core.Ports
{
    public interface IRegisterInputPort
    {
        Task RegisterAppAsync(RegisterDTO registerDTO);
    }
}
