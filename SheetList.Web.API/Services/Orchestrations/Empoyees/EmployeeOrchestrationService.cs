
using SheetList.Web.API.Models;
using SheetList.Web.API.Services.Foundations.ExcelFile;
using SheetList.Web.API.Services.Processings.Empoyees;

namespace SheetList.Web.API.Services.Orchestrations.Empoyees
{
    public class EmployeeOrchestrationService : IEmployeeOrchestrationService
    {
        private readonly IEmployeeProcessingService employeeProcessingService;
        private readonly IFileService fileService;

        public EmployeeOrchestrationService(
            IEmployeeProcessingService employeeProcessingService,
            IFileService fileService)
        {
            this.employeeProcessingService = employeeProcessingService;
            this.fileService = fileService;
        }

        public async Task<string> AddFileAsync(Stream fileStream, string fileName, string contentType) =>
            await this.fileService.AddFileAsync(fileStream, fileName, contentType);

        public async Task<Stream> DownloadAsync(string fileName) =>
            await this.fileService.DownloadFileAsync(fileName);

        public async Task<List<ExcelRowData>> ExcelDataAsync(string fileName) =>
            await this.employeeProcessingService.ExtractExcelDataAsync(fileName);
    }
}
