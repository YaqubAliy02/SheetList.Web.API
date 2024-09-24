using Microsoft.EntityFrameworkCore;
using SheetList.Web.API.Models;

namespace SheetList.Web.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<FileData> Files { get; set; }

        public async ValueTask<FileData> InsertFileDataAsync(FileData fileData) =>
           await InsertAsync(fileData);

        public async ValueTask<IQueryable<FileData>> SelectAllFileDatas() =>
            await SelectAllAsync<FileData>();

        public async ValueTask<FileData> SelectFileDataByIdAsync(Guid id) =>
            await SelectAsync<FileData>(id);

        public async ValueTask<FileData> UpdateFileDataAsync(FileData fileData) =>
            await UpdateAsync(fileData);

        public async ValueTask<FileData> DeleteFileDataAsync(FileData fileData) =>
            await DeleteAsync(fileData);
    }
}
