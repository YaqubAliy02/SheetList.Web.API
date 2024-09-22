using SheetList.Web.API.Models.Orchestrations.Files;
using SheetList.Web.API.Models;

namespace SheetList.Web.API.Services.Processings.Employees
{
    public interface IEmployeeProcessingService
    {
        Task<int> ImportExternalFileToTable(IFormFile postedFile);
        FileConfiguration ConvertSqlDataToXmlFile();
        ValueTask<IQueryable<Employee>> RetrieveAllEmployees();
    }
}
