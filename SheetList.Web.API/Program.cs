using SheetList.Web.API.Brokers.Blobs;
using SheetList.Web.API.Brokers.Loggings;
using SheetList.Web.API.Brokers.Storages;
using SheetList.Web.API.Services.Foundations.ExcelFile;
using SheetList.Web.API.Services.Foundations.FileDatas;
using SheetList.Web.API.Services.Orchestrations.Empoyees;
using SheetList.Web.API.Services.Processings.Empoyees;

namespace SheetList.Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IStorageBroker, StorageBroker>();
            builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
            builder.Services.AddTransient<IBlobBroker, BlobBroker>();
            builder.Services.AddTransient<IFileService, FileService>();
            builder.Services.AddTransient<IEmployeeProcessingService, EmployeeProcessingService>();
            builder.Services.AddTransient<IEmployeeOrchestrationService, EmployeeOrchestrationService>();
            builder.Services.AddScoped<IFileDataService, FileDataService>();
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
