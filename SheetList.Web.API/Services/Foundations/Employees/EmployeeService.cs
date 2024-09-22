using SheetList.Web.API.Brokers.Storages;
using SheetList.Web.API.Models;

namespace SheetList.Web.API.Services.Foundations.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IStorageBroker storageBroker;

        public EmployeeService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Employee> AddEmployeeAsync(Employee employee) =>
          await this.storageBroker.InsertEmployeeAsync(employee);

        public ValueTask<IQueryable<Employee>> RetrieveAllEmployees() =>
            this.storageBroker.SelectAllEmployees();

        public async ValueTask<Employee> ModifyEmployeeAsync(Employee employee) =>
            await this.storageBroker.UpdateEmployeeAsync(employee);

        public async ValueTask<Employee> RemoveEmployeeAsync(Employee employee) =>
             await this.storageBroker.DeleteEmployeeAsync(employee);
    }
}
