/*using Moq;
using SheetList.Web.API.Brokers.Storages;
using Tynamix.ObjectFiller;

namespace SheetList.Web.API.Unit.Test.Services.Foundations.Employees
{
    public partial class EmployeeServiceTest
    {
        public readonly Mock<IStorageBroker> storageBrokerMock;
        public readonly IEmployeeService employeeServiceMock;

        public EmployeeServiceTest()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();

            this.employeeServiceMock =
                new EmployeeService(this.storageBrokerMock.Object);
        }

        private static Employee CreateRandomEmployee() =>
            CreateEmployeeFiller(date: GetRandomDateTimeOffset()).Create();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<Employee> CreateEmployeeFiller(DateTimeOffset date)
        {
            var filler = new Filler<Employee>();
            filler.Setup().OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
*/