namespace Rubns.Application.Login.Post
{
    internal class LogInUseCase : IPostLogInPort<JWT>
    {
        IEncryptionService EncryptionService { get; }
        ILogInRepository LogInRepository { get; }
        ILogInService LogInService { get; }
        ILogger Logger { get; }
        public LogInUseCase(IEncryptionService encryptionService,
            ILogInRepository logInRepository,
            ILogInService logInService,
            ILogger logger)
        {
            EncryptionService = encryptionService;
            LogInRepository = logInRepository;
            LogInService = logInService;
            Logger = logger;
        }

        public async Task<JWT> LogIn(LoginRequestDTO login)
        {
            JWT jwt = new();
            try
            {
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

            }
            catch (Exception e)
            {
                Logger.Error(e, "LogIn an error occurred: {ErrorMessage}", e.Message);
            }

            return jwt;
        }
    }
}
