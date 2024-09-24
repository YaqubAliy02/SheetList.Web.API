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
    }
}
