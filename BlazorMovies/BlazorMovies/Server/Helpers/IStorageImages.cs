namespace BlazorMovies.Server.Helpers
{
    public interface IStorageImages
    {
        Task<string> SaveFile(byte[] content, string extension, string nameContainer);
        Task DeleteFile(string path, string nameContainer);
        Task<string> EditFile(byte[] content, string extension, string nameContainer, string path);
    }
}
