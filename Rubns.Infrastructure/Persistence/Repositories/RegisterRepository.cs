﻿namespace Rubns.Infrastructure.Persistence.Repositories
{
    internal class RegisterRepository : IRegisterRepository
    {
        ApplicationDbContextEFC Context { get; }

        public RegisterRepository(ApplicationDbContextEFC context)
        {
            Context = context;
        }

        public async Task<int> RegisterApplicationAsync(TokenRegisterDTO token)
        {
            try
            {
                var collection = new[]
                {
                    new { Key = "ApiKey", Value = token.Token },
                    new { Key = "NameApplication", Value = token.NameApplicacion },
                    new { Key = "UserName", Value = token.UserRegisted }
                };

                await using var connection = new SqlConnection(Context.Database.GetConnectionString());
                await connection.OpenAsync();

                string query = "usp_InsertApiKey_v1";

                var result = await connection.ExecuteAsync(query, collection, commandType: CommandType.StoredProcedure);

                await connection.CloseAsync();
                return result;

            }
            catch
            {
                throw;
            }
        }
    }
}
