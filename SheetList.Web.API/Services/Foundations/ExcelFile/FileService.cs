using SheetList.Web.API.Brokers.Blobs;

namespace SheetList.Web.API.Services.Foundations.ExcelFile
{
    public class FileService : IFileService
    {
        private readonly IBlobBroker blobBroker;

        public FileService(IBlobBroker blobBroker)
        {
            this.blobBroker = blobBroker;
        }

        public async Task<string> AddFileAsync(Stream fileStream, string fileName, string contentType) =>
             await blobBroker.UploadFileAsync(fileStream, fileName, contentType);

        public async Task<Stream> DownloadFileAsync(string fileName) =>
            await blobBroker.DownloadFileAsync(fileName);
    }
}
