
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
            var nameFile = Path.GetFileName(path);
            var directoryFile = Path.Combine(env.WebRootPath, nameContainer, nameFile);
            if (File.Exists(directoryFile))
            {
                File.Delete(directoryFile);
            }

            return Task.CompletedTask;
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
            // folder\directory\file
            var pathDB = Path.Combine(urlActual, nameContainer, nameFile).Replace("\\","/");
            return pathDB;
        }
    }
}
