﻿
namespace Rubns.Infrastructure.Persistence.Repositories.DB_Auth
{
    class LogInRepository : ILogInRepository
    {
        AuthDbContextEFC AuthDbContextEFC { get; }

        public LogInRepository(AuthDbContextEFC authDbContextEFC)
        {
            AuthDbContextEFC = authDbContextEFC;
        }
        public async Task<UserDTO> GetUserByEmail(string email)
        {
            UserDTO result = new();
            try
            {
                await using var connection = new SqlConnection(AuthDbContextEFC.Database.GetConnectionString());
                await connection.OpenAsync();

                var proc = "p_UserByEmail";

                var user = await connection.QuerySingleOrDefaultAsync<UserDTO>(proc, new { email }, commandType: CommandType.StoredProcedure);
                await connection.CloseAsync();

                if (user is not null)
                {
                    result = user;
                }

            }
            catch
            {
                throw;
            }

            return result;
        }
    }
}
