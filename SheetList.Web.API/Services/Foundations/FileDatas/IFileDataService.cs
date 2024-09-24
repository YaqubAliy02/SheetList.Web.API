using SheetList.Web.API.Models;

namespace SheetList.Web.API.Services.Foundations.FileDatas
{
    public interface IFileDataService
    {
        Task<FileData> AddFileDataAsync(FileData data);
        Task<IQueryable<FileData>> GetAllFileDataAsync();
        Task<FileData> UpdateFileDataAsync(FileData data);
        Task<FileData> DeleteFileDataAsync(FileData data);
        Task<FileData> GetFileDataByIdAsync(Guid id);

    }
}
