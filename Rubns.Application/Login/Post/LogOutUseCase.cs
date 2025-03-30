using Rubns.Core.DTOs.LogIn;

namespace Rubns.Application.Login.Post
{
    internal class LogOutUseCase : ILogOutPort
    {
        private readonly ISessionUserRepository SessionUserRepository;
        private readonly ILogger Logger;

        public LogOutUseCase(ISessionUserRepository sessionUserRepository
            , ILogger logger)
        {
            SessionUserRepository = sessionUserRepository;
            Logger = logger;
        }

        public async Task<bool> LogOut(RefreshTokenRequestDTO token)
        {
            bool result = false;
            try
            {

                return await SessionUserRepository.DeleteSessionAsync(token.RefreshToken) > 0;

            }
            catch (Exception e)
            {
                Logger.Error(e, "Error LogOut");
            }

            return result;
        }
    }
}
