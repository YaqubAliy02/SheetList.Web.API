using SheetList.Web.API.Models;

namespace SheetList.Web.API.Services.Orchestrations.Empoyees
{
    public interface IEmployeeOrchestrationService
    {
        Task<string> AddFileAsync(Stream fileStream, string fileName, string contentType);
        Task<Stream> DownloadAsync(string fileName);
        Task<List<ExcelRowData>> ExcelDataAsync(string fileName);
    }
}
