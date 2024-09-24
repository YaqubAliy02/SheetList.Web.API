using SheetList.Web.API.Models;

namespace SheetList.Web.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<FileMetadata> InsertFileMetadataAsync(FileMetadata fileMetadata);
        ValueTask<IQueryable<FileMetadata>> SelectAllFileMetadatas();
        ValueTask<FileMetadata> UpdateFileMetadataAsync(FileMetadata fileMetadata);
        ValueTask<FileMetadata> DeleteFileMetadataAsync(FileMetadata fileMetadata);
    }
}
