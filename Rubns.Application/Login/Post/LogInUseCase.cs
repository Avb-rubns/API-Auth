namespace Rubns.Application.Login.Post
{
    internal class LogInUseCase : IPostLogInPort<JWT>
    {
        IEncryptionService EncryptionService { get; }
        ILogInRepository LogInRepository { get; }
        ILogInService LogInService { get; }
        public LogInUseCase(IEncryptionService encryptionService
            , ILogInRepository logInRepository
            , ILogInService logInService)
        {
            EncryptionService = encryptionService;
            LogInRepository = logInRepository;
            LogInService = logInService;
        }

        public async Task<JWT> LogIn(LoginRequestDTO login)
        {
            JWT jwt = new();
            var user = await LogInRepository.GetUserByEmail(login.Email);
            if (user.Email is null)
            {
                return null;
            }
            if (!EncryptionService.ValidatePass(login.Password, user.Password))
            {
                return null;

            }

            jwt = LogInService.CreateJWT(user);

            return jwt;
        }
    }
}
