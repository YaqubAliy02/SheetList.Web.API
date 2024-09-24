using SheetList.Web.API.Models;

namespace SheetList.Web.API.Services.Processings.Empoyees
{
    public interface IEmployeeProcessingService
    {
        Task<List<ExcelRowData>> ExtractExcelDataAsync(string fileName);
    }
}
