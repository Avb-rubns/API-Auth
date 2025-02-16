namespace Rubns.Application.Register.Post
{
    internal class GenerateKeyUseCase : IGenerateKeyPort<Response<string>>
    {
        IEncryptionService EncryptionService { get; }
        IConfiguration Configuration { get; }

        public GenerateKeyUseCase(IEncryptionService encryptionService
            ,IConfiguration configuration)
        {
            EncryptionService = encryptionService;
            Configuration = configuration;
        }

        public Response<string> GenerateKey(RegisterDTO register)
        {
            try
            {
                var token = EncryptionService.GenerateToken(register, Configuration["WordSecret"]);
                if (!string.IsNullOrEmpty(token))
                {
                    return Response<string>.Ok(token);

                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Response<string>.Error("No se puede generar el apikey en estos momentos.");
        }
    }
}
