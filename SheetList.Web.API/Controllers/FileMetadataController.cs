using Microsoft.AspNetCore.Mvc;
using SheetList.Web.API.Models;
using SheetList.Web.API.Services.Foundations.ExcelFile;
using SheetList.Web.API.Services.Orchestrations.Empoyees;

namespace ODS.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IFileService fileService;
        private readonly IEmployeeOrchestrationService employeeOrchestrationService;

        public EmployeeController(IFileService fileService,
            IEmployeeOrchestrationService employeeOrchestrationService)
        {
            this.fileService = fileService;
            this.employeeOrchestrationService = employeeOrchestrationService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadEBook(IFormFile file)
        {
            if (file is null || !ValidateEBook(file))
            {
                throw new ArgumentNullException("File is not valid format");
            }
            using var stream = file.OpenReadStream();
            var blobUri = await this.fileService.AddFileAsync(stream, file.FileName, file.ContentType);

            var eBook = new FileMetadata
            {
                Id = Guid.NewGuid(),
                FileName = file.FileName,
                ContentType = file.ContentType,
                Size = file.Length,
                BlobUri = blobUri,
                UploadedDate = DateTime.UtcNow,
            };

            return Ok(eBook);
        }

        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> DownloadEbook(string fileName)
        {
            try
            {
                var ebookStream = await this.fileService.DownloadFileAsync(fileName);

                if (ebookStream == null)
                {
                    return NotFound();
                }

                var extension = Path.GetExtension(fileName).ToLower();
                string contentType = extension switch
                {
                    ".xls" => "application/vnd.ms-excel",
                    ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    _ => throw new Exception("Only Excel files (.xls, .xlsx) are supported.") 
                };


                return File(ebookStream, contentType, fileName);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("extract")]
        public async Task<IActionResult> ExtractData([FromQuery] string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return BadRequest("Blob path is missing.");
            }

            var extractedData = await this.employeeOrchestrationService.ExcelDataAsync(fileName);
            return Ok(extractedData);
        }
        private bool ValidateEBook(IFormFile file)
        {
            var allowedExtensions = new[] { ".xls", ".xlsx" };

            var extension = Path.GetExtension(file.FileName)?.ToLower();

            if (file is null || file.Length is 0)
            {
                Console.WriteLine("File cannot be null or empty.");
                return false;
            }
            if (file.Length > 50 * 1024 * 1024)
            {
                Console.WriteLine("The file size exceeds the 50 MB limit.");
                return false;
            }
            if (!allowedExtensions.Contains(extension))
            {
                Console.WriteLine($"The file must have one of the allowed extensions: {string.Join(", ", allowedExtensions)}.");
                return false;
            }

            Console.WriteLine("File is valid.");
            return true;
        }
    }
}
