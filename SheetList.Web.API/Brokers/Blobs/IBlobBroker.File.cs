namespace SheetList.Web.API.Brokers.Blobs
{
    public partial interface IBlobBroker
    {
        Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType);
        Task<Stream> DownloadEbookAsync(string fileName);
    }
}
