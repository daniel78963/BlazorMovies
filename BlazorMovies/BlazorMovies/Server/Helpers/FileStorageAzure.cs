﻿
using Azure.Storage.Blobs;

namespace BlazorMovies.Server.Helpers
{
    public class FileStorageAzure : IStorageFiles
    {
        private string connectionString;
        public FileStorageAzure(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorage")!;
        }

        public async Task DeleteFile(string path, string nameContainer)
        {
            var client = new BlobContainerClient(connectionString, nameContainer);
            //Crear el contenedor si no existe
            await client.CreateIfNotExistsAsync();
            var nameFile = Path.GetFileName(path);
            var blob = client.GetBlobClient(nameFile);
            await blob.DeleteIfExistsAsync();
        }

        public async Task<string> SaveFile(byte[] content, string extension, string nameContainer)
        {
            var client = new BlobContainerClient(connectionString, nameContainer);
            //Crear el contenedor si no existe
            await client.CreateIfNotExistsAsync();
            client.SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

            var nameFile = $"{Guid.NewGuid()}{extension}";
            var blob = client.GetBlobClient(nameFile);

            using (var ms = new MemoryStream(content))
            {
                await blob.UploadAsync(ms);
            } 

            return blob.Uri.ToString();
        }
    }
}
