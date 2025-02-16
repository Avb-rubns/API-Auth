namespace Rubns.Application.Register.Post
{
    internal class RegisterAppUseCase : IRegisterInputPort
    {
        IEncryptionService EncryptionService { get;  }
        IConfiguration Configuration { get; }

        public RegisterAppUseCase(IEncryptionService encryptionService, IConfiguration configuration )
        {
            EncryptionService = encryptionService;
            Configuration = configuration;
        }

        public Task RegisterAppAsync(RegisterDTO registerDTO)
        {
            try
            {
                var secret = Configuration["WordSecret"];
                var apikey = EncryptionService.GenerateToken(registerDTO,secret);


            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            throw new NotImplementedException();
        }
    }
}
