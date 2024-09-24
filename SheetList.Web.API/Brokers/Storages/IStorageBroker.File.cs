using SheetList.Web.API.Models;

namespace SheetList.Web.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<FileData> InsertFileDataAsync(FileData fileData);
        ValueTask<IQueryable<FileData>> SelectAllFileDatas();
        ValueTask<FileData> SelectFileDataByIdAsync(Guid id);
        ValueTask<FileData> UpdateFileDataAsync(FileData fileData);
        ValueTask<FileData> DeleteFileDataAsync(FileData fileData);
    }
}
