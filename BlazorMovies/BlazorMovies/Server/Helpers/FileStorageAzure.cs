
namespace BlazorMovies.Server.Helpers
{
    public class FileStorageAzure : IStorageFiles
    {
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
