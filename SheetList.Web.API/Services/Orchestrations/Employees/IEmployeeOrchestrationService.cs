using SheetList.Web.API.Models.Orchestrations.Files;
using SheetList.Web.API.Models;

namespace SheetList.Web.API.Services.Orchestrations.Employees
{
    public interface IEmployeeOrchestrationService
    {
        Task<IQueryable<Employee>> RetrieveEmployeeAscendingOrderAsync(string orderby);
        Task<int> ImportExternalFileToTable(IFormFile postedFile);
        FileConfiguration ConvertSqlDataToXmlFile();
    }
}