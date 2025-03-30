using Rubns.Core.DTOs.LogOut;

namespace Rubns.Infrastructure.Persistence.Repositories.DB_Auth
{
    internal class SessionUserRepository : ISessionUserRepository
    {
        private readonly AuthDbContextEFC AuthDbContextEFC;
        private readonly IConfiguration Configuration;
        public SessionUserRepository(AuthDbContextEFC authDbContext, IConfiguration configuration)
        {
            AuthDbContextEFC = authDbContext;
            Configuration = configuration;
        }
        public async Task<int> AddSessionAsync(int userId, string token)
        {
            SessionUser sessionUser = new()
            {
                Token = token,
                UserID = userId,
                Expiration = DateTime.UtcNow.AddDays(Convert.ToDouble(Configuration["DaysRefresh"]))
            };

            await AuthDbContextEFC.AddAsync(sessionUser);
            return await AuthDbContextEFC.SaveChangesAsync();
        }

        public async Task<int> DeleteSessionAsync(string token)
        {

            using (var connection = new SqlConnection(AuthDbContextEFC.Database.GetConnectionString()))
            {
                await connection.OpenAsync();
                var parameters = new { Token = token };

                int result = await connection.ExecuteScalarAsync<int>(
                    "p_DeleteSessionUser",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public Task<SessionUserDTO> FindAsyn(string token)
        {
            throw new NotImplementedException();
        }
    }
}
