using SheetList.Web.API.Brokers.Storages;
using SheetList.Web.API.Models;

namespace SheetList.Web.API.Services.Foundations.FileDatas
{
    public class FileDataService : IFileDataService
    {
        private readonly IStorageBroker storageBroker;

        public FileDataService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async Task<FileData> AddFileDataAsync(FileData data) =>
           await this.storageBroker.InsertFileDataAsync(data);

        public async Task<IQueryable<FileData>> GetAllFileDataAsync() =>
           await this.storageBroker.SelectAllFileDatas();

        public async Task<FileData> GetFileDataByIdAsync(Guid id) =>
            await this.storageBroker.SelectFileDataByIdAsync(id);

        public async Task<FileData> UpdateFileDataAsync(FileData data) =>
            await this.storageBroker.UpdateFileDataAsync(data);

        public async Task<FileData> DeleteFileDataAsync(FileData data) =>
           await this.storageBroker.DeleteFileDataAsync(data);
    }

}
