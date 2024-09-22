using SheetList.Web.API.Brokers.Loggings;
using SheetList.Web.API.Models.Orchestrations.Files;
using SheetList.Web.API.Models;
using SheetList.Web.API.Services.Processings.Employees;

namespace SheetList.Web.API.Services.Orchestrations.Employees
{
    public class EmployeeOrchestrationService : IEmployeeOrchestrationService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IEmployeeProcessingService employeeProcessingService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EmployeeOrchestrationService(
            IEmployeeProcessingService employeeProcessingService,
            ILoggingBroker loggingBroker, IWebHostEnvironment webHostEnvironment)
        {
            this.employeeProcessingService = employeeProcessingService;
            this.loggingBroker = loggingBroker;
            this.webHostEnvironment = webHostEnvironment;
        }

        public Task<int> ImportExternalFileToTable(IFormFile postedFile) =>
           this.employeeProcessingService.ImportExternalFileToTable(postedFile);

        public FileConfiguration ConvertSqlDataToXmlFile() =>
            this.employeeProcessingService.ConvertSqlDataToXmlFile();

        public async Task<IQueryable<Employee>> RetrieveEmployeeAscendingOrderAsync(string orderby)
        {
            IQueryable<Employee> employees = await this.employeeProcessingService.RetrieveAllEmployees();

            IQueryable<Employee> ascendingOrderedEmployees = orderby switch
            {
                "firstname" => employees.OrderBy(x => x.FirstName),
                "lastname" => employees.OrderBy(x => x.LastName),
                _ => employees
            };

            return ascendingOrderedEmployees;
        }
    }   
}
