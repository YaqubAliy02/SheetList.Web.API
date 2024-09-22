using Microsoft.EntityFrameworkCore;
using SheetList.Web.API.Models;

namespace SheetList.Web.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Employee> Employees { get; set; }

        public async ValueTask<Employee> InsertEmployeeAsync(Employee Employee) =>
           await InsertAsync(Employee);

        public async ValueTask<IQueryable<Employee>> SelectAllEmployeesAsync() =>
            await SelectAllAsync<Employee>();

        public async ValueTask<Employee> SelectEmployeeByIdAsync(Guid EmployeeId) =>
            await SelectAsync<Employee>(EmployeeId);

        public async ValueTask<Employee> UpdateEmployeeAsync(Employee Employee) =>
            await UpdateAsync(Employee);

        public async ValueTask<Employee> DeleteEmployeeAsync(Employee Employee) =>
            await DeleteAsync(Employee);
    }
}
