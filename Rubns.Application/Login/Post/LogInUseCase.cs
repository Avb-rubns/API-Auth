
namespace Rubns.Application.Login.Post
{
    internal class LogInUseCase : IPostLogInPort<AuthResponseDTO>
    {
        IEncryptionService EncryptionService { get; }
        ILogInRepository LogInRepository { get; }
        ILogInService LogInService { get; }
        ILogger Logger { get; }
        ISessionUserRepository SessionUserRepository { get; }
        public LogInUseCase(IEncryptionService encryptionService,
            ILogInRepository logInRepository,
            ILogInService logInService,
            ILogger logger,
            ISessionUserRepository sessionUserRepository)
        {
            EncryptionService = encryptionService;
            LogInRepository = logInRepository;
            LogInService = logInService;
            Logger = logger;
            SessionUserRepository = sessionUserRepository;
        }

        public async Task<AuthResponseDTO> LogIn(LoginRequestDTO login)
        {
            AuthResponseDTO auth = new();
            JWT jwt = new();
            string refreshToken = string.Empty;
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
                refreshToken = LogInService.CreateRefreshToken();
                if (jwt is not null && !string.IsNullOrEmpty(refreshToken))
                {

                    var saveSessionUser = await SessionUserRepository.AddSessionAsync(user.UserID, refreshToken);

                    if (saveSessionUser > 0)
                    {
                        auth.RefreshToken = refreshToken;
                        auth.AccessToken = jwt;

                    }
                }

            }
            catch (Exception e)
            {
                Logger.Error(e, "LogIn an error occurred: {ErrorMessage}", e.Message);
            }

            return auth;
        }
    }
}
