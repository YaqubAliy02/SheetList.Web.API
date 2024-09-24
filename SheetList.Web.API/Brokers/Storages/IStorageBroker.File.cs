using SheetList.Web.API.Models;

namespace SheetList.Web.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<FileData> InsertFileMetadataAsync(FileData fileData);
        ValueTask<IQueryable<FileData>> SelectAllFileMetadatas();
        ValueTask<FileData> UpdateFileMetadataAsync(FileData fileData);
        ValueTask<FileData> DeleteFileMetadataAsync(FileData fileData);
    }
}
