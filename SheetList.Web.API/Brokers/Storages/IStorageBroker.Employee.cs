using SheetList.Web.API.Models;

namespace SheetList.Web.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Employee> InsertEmployeeAsync(Employee employee);
        ValueTask<IQueryable<Employee>> SelectAllEmployees();
        ValueTask<Employee> UpdateEmployeeAsync(Employee employee);
        ValueTask<Employee> DeleteEmployeeAsync(Employee employee);
    }
}
