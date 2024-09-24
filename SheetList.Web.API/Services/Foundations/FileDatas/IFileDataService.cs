using SheetList.Web.API.Models;

namespace SheetList.Web.API.Services.Foundations.FileDatas
{
    public interface IFileDataService
    {
        Task<FileData> AddFileDataAsync(FileData fileData);
        Task<IQueryable<FileData>> GetAllFileDataAsync();
        Task<FileData> UpdateFileDataAsync(FileData fileData);
        Task<FileData> DeleteFileDataAsync(Guid fileData);
        Task<FileData> GetFileDataByIdAsync(Guid fileId);

    }
}
