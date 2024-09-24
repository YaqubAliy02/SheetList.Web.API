using Microsoft.EntityFrameworkCore;
using SheetList.Web.API.Models;

namespace SheetList.Web.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<FileMetadata> FileMetadatas { get; set; }

        public async ValueTask<FileMetadata> InsertFileMetadataAsync(FileMetadata fileMetadata) =>
           await InsertAsync(fileMetadata);

        public async ValueTask<IQueryable<FileMetadata>> SelectAllFileMetadatas() =>
            await SelectAllAsync<FileMetadata>();

        public async ValueTask<FileMetadata> UpdateFileMetadataAsync(FileMetadata fileMetadata) =>
            await UpdateAsync(fileMetadata);

        public async ValueTask<FileMetadata> DeleteFileMetadataAsync(FileMetadata fileMetadata) =>
            await DeleteAsync(fileMetadata);
    }
}
