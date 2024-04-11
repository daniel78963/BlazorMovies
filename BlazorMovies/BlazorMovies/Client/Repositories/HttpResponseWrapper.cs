using System.Net;

namespace BlazorMovies.Client.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public bool Error { get; set; }
        public T? Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string?> GetMessageError()
        {
            if (!Error)
            {
                return null;
            }

            var statusCode = HttpResponseMessage.StatusCode;
            if (statusCode == HttpStatusCode.NotFound)
            {
                return "Resource not found";
            }
            else if (statusCode == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            else if(statusCode == HttpStatusCode.Unauthorized)
            {
                return "You need loggin to do this";
            }
            else if( statusCode == HttpStatusCode.Forbidden)
            {
                return "You do not have permissions to do this";
            }
            else
            {
                return "An unexpected error has occurred";
            }
        }
    }
}
