namespace Rubns.Core.POCO
{
    public class Response<TResponse>
    {



        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public int Status { get; set; }
        public TResponse Result { get; set; }

        public Response(TResponse response)
        {
            Success = true;
            Result = response;
        }
        public Response(List<string> errors)
        {
            Success = false;
            Errors = errors;
        }


        public static Response<TResponse> Ok(TResponse response)
        {
            return new Response<TResponse>(response);
        }


        public static Response<TResponse> Error(List<string> errors)
        {
            return new Response<TResponse>(errors);
        }

        public static Response<TResponse> Error(string error)
        {
            return new Response<TResponse>(new List<string> { error });
        }
    }
}
