namespace SheetList.Web.API.Services.Foundations.ExcelFile
{
    public interface IFileService
    {
        Task<string> AddFileAsync(Stream fileStream, string fileName, string contentType);
        Task<Stream> DownloadFileAsync(string fileName);
    }
}
