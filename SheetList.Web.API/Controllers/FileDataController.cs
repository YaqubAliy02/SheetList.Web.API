using Microsoft.AspNetCore.Mvc;
using SheetList.Web.API.Models;
using SheetList.Web.API.Services.Foundations.FileDatas;

namespace SheetList.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileDataController : ControllerBase
    {
        private readonly IFileDataService fileDataService;

        public FileDataController(IFileDataService fileDataService)
        {
            this.fileDataService = fileDataService;
        }

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<IQueryable<FileData>>> GetAllFileDatas()
        {
            IQueryable<FileData> gettingAllFileDatas = await this.fileDataService.GetAllFileDataAsync();

            return Ok(gettingAllFileDatas);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetFileDataByIdAsync(Guid id)
        {
            var getFileDataByIdAsync = await this.fileDataService.GetFileDataByIdAsync(id);
            
            return Ok(getFileDataByIdAsync);
        }

        [HttpPost("[action]")]
        public async ValueTask<ActionResult<FileData>> PostFileDataAsync(FileData fileData)
        {
            FileData postedFileData = await this.fileDataService.AddFileDataAsync(fileData);

            return Ok(postedFileData);
        }

        [HttpPut("[action]")]
        public async ValueTask<ActionResult<FileData>> PutFileDataAsync(FileData fileData)
        {
            FileData modifiedFileData = await this.fileDataService.UpdateFileDataAsync(fileData);

            return Ok(modifiedFileData);
        }

        [HttpDelete("[action]")]
        public async ValueTask<ActionResult<FileData>> DeleteFileDataById(Guid filedataId)
        {
            FileData mightBeDeleteFileData = await this.fileDataService.GetFileDataByIdAsync(filedataId);

            if (mightBeDeleteFileData is not null)
            {
                FileData modifiedFileData = await this.fileDataService.DeleteFileDataAsync(filedataId);
                return Ok($"{modifiedFileData.FileName} file is deleted successfully");
            }
            return Ok($"{mightBeDeleteFileData.FileName} is not exist!!!");
        }
    }
}