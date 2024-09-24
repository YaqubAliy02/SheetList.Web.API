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

        public async Task<FileData> AddFileDataAsync(FileData filData) =>
           await this.storageBroker.InsertFileDataAsync(filData);

        public async Task<IQueryable<FileData>> GetAllFileDataAsync() =>
           await this.storageBroker.SelectAllFileDatas();

        public async Task<FileData> GetFileDataByIdAsync(Guid filDataId) =>
            await this.storageBroker.SelectFileDataByIdAsync(filDataId);

        public async Task<FileData> UpdateFileDataAsync(FileData filData) =>
            await this.storageBroker.UpdateFileDataAsync(filData);

        public async Task<FileData> DeleteFileDataAsync(Guid filDataId) =>
           await this.storageBroker.DeleteFileDataAsync(filDataId);
    }

}
