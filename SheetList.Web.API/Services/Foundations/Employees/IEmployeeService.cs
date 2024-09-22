using SheetList.Web.API.Models;

namespace SheetList.Web.API.Services.Foundations.Employees
{
    public interface IEmployeeService
    {
        ValueTask<Employee> AddEmployeeAsync(Employee employee);
        ValueTask<IQueryable<Employee>> RetrieveAllEmployees();
        ValueTask<Employee> ModifyEmployeeAsync(Employee employee);
        ValueTask<Employee> RemoveEmployeeAsync(Employee employee);
    }
}
