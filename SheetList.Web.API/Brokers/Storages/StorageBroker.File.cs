using Microsoft.EntityFrameworkCore;
using SheetList.Web.API.Models;

namespace SheetList.Web.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<FileData> Files { get; set; }

        public async ValueTask<FileData> InsertFileMetadataAsync(FileData fileData) =>
           await InsertAsync(fileData);

        public async ValueTask<IQueryable<FileData>> SelectAllFileMetadatas() =>
            await SelectAllAsync<FileData>();

        public async ValueTask<FileData> UpdateFileMetadataAsync(FileData fileData) =>
            await UpdateAsync(fileData);

        public async ValueTask<FileData> DeleteFileMetadataAsync(FileData fileData) =>
            await DeleteAsync(fileData);
    }
}
