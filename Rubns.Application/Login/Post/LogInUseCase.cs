
using System.Threading.Tasks;

namespace Rubns.Application.Login.Post
{
    internal class LogInUseCase : IPostLogInPort<JWT>
    {
        IEncryptionService EncryptionService { get; }
        ILogInRepository LogInRepository { get; }
        public LogInUseCase(IEncryptionService encryptionService
            , ILogInRepository logInRepository)
        {
            EncryptionService = encryptionService;
            LogInRepository = logInRepository;
        }

        public async Task<JWT> LogIn(LoginRequestDTO login)
        {
            var user = await LogInRepository.GetUserByEmail(login.Email);

            if (EncryptionService.ValidatePass(login.Password, "a"))
            {

            }

            throw new NotImplementedException();
        }
    }
}
