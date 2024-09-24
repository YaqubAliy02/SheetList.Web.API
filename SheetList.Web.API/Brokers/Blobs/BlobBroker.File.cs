using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using SheetList.Web.API.Models;

namespace SheetList.Web.API.Brokers.Blobs
{
    public partial class BlobBroker
    {
        public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType) =>
           await UploadAsync(fileStream, fileName, contentType);

        public async Task<List<FileMetadata>> SelectAllPhotosAsync()
        {
            var blobServiceClient = new BlobServiceClient(blobConnectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(fileContainerName);
            var blobItems = blobContainerClient.GetBlobsAsync();
            var allowedExtensions = new[] { ".xls", ".xlsx" };

            var files = new List<FileMetadata>();

            await foreach (BlobItem blobItem in blobItems)
            {
                var blobClient = blobContainerClient.GetBlobClient(blobItem.Name);
                var extension = Path.GetExtension(blobItem.Name);

                if (allowedExtensions.Contains(extension))
                {
                    var properties = await blobClient.GetPropertiesAsync();

                    files.Add(new FileMetadata
                    {
                        Id = Guid.NewGuid(),
                        FileName = blobItem.Name,
                        ContentType = properties.Value.ContentType,
                        Size = properties.Value.ContentLength,
                        BlobUri = blobClient.Uri.ToString(),
                        UploadedDate = properties.Value.CreatedOn.DateTime
                    });
                }
            }
            return files;
        }

        public async Task<Stream> DownloadFileAsync(string fileName)
        {
            var blobServiceClient = new BlobServiceClient(blobConnectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(fileContainerName);
            var blobClient = blobContainerClient.GetBlobClient(fileName);

            var exists = await blobClient.ExistsAsync();

            if (!exists)
            {
                throw new FileNotFoundException($"E-book with filename '{fileName}' does not exist.");
            }

            BlobDownloadInfo download = await blobClient.DownloadAsync();
            return download.Content;
        }
    }
}
