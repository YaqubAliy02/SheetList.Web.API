using Azure.Storage.Blobs;

namespace SheetList.Web.API.Brokers.Blobs
{
    public partial class BlobBroker : IBlobBroker
    {
        private readonly string blobConnectionString;
        private readonly string fileContainerName;
        private readonly HashSet<string> fileExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { ".xls", ".xlsx" };

        public BlobBroker(IConfiguration configuration)
        {
            blobConnectionString = configuration["AzureBlobStorage:ConnectionString"];
            fileContainerName = configuration["AzureBlobStorage:FileContainerName"];
        }

        public async Task<string> UploadAsync(Stream fileStream, string fileName, string contentType)
        {
            var extension = Path.GetExtension(fileName).ToLower();
            var blobContainerName = GetContainerName(extension);

            if (blobContainerName == null)
            {
                throw new InvalidOperationException("Unsupported file type.");
            }

            var blobServiceClient = new BlobServiceClient(blobConnectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);
            var blobClient = blobContainerClient.GetBlobClient(fileName);

            await blobClient.UploadAsync(fileStream, true);

            return blobClient.Uri.ToString();
        }

        private string GetContainerName(string extension)
        {
            if (fileExtensions.Contains(extension))
            {
                return fileContainerName;
            }
            return null;
        }
    }
}
