namespace BlazorMovies.Server.Helpers
{
    public interface IStorageFiles
    {
        Task<string> SaveFile(byte[] content, string extension, string nameContainer);
        Task DeleteFile(string path, string nameContainer);
        async Task<string> EditFile(byte[] content, string extension
            , string nameContainer, string path)
        {
            if (path is not null)
            {
                await DeleteFile(path, nameContainer);
            }

            return await SaveFile(content, extension, nameContainer);
        }
    }
}
