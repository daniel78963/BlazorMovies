
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

        public async Task<string> SaveFile(byte[] content, string extension, string nameContainer)
        {
            var nameFile = $"{Guid.NewGuid()}{extension}";
            var folder = Path.Combine(env.WebRootPath, nameContainer);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string pathSave = Path.Combine(folder, nameFile);
            await File.WriteAllBytesAsync(pathSave, content);

            var urlActual = $"{httpContextAccessor!.HttpContext!.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";
            var pathDB = Path.Combine(urlActual, nameContainer, nameFile);
            return pathDB;
        }
    }
}
