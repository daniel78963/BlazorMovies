
namespace BlazorMovies.Server.Helpers
{
    public class FileStorageLocal : IStorageFiles
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;

        public FileStorageLocal(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }

        public Task DeleteFile(string path, string nameContainer)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveFile(byte[] content, string extension, string nameContainer)
        {
            throw new NotImplementedException();
        }
    }
}
