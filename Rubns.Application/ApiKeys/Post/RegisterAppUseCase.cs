using Rubns.Core.DTOs.ApiKey;
using Rubns.Core.Ports.ApiKey.Register;

namespace Rubns.Application.Register.Post
{
    internal class RegisterAppUseCase : IRegisterInputPort
    {
        IEncryptionService EncryptionService { get;  }

        public RegisterAppUseCase(IEncryptionService encryptionService )
        {
            EncryptionService = encryptionService;
        }

        public Task RegisterAppAsync(RegisterDTO registerDTO, HttpRequest? request)
        {
            try
            {
                var apikey = EncryptionService.GenerateApiKey(registerDTO);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            throw new NotImplementedException();
        }
    }
}
