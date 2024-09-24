using OfficeOpenXml;
using SheetList.Web.API.Models;
using SheetList.Web.API.Services.Foundations.ExcelFile;

namespace SheetList.Web.API.Services.Processings.Empoyees
{
    public class EmployeeProcessingService : IEmployeeProcessingService
    {
        private readonly IFileService fileService;

        public EmployeeProcessingService(IFileService fileService)
        {
            this.fileService = fileService;
        }
        public async Task<List<ExcelRowData>> ExtractExcelDataAsync(string fileName)
        {
            Stream fileStream = await this.fileService.DownloadFileAsync(fileName);

            var rows = new List<ExcelRowData>();
            using (var package = new ExcelPackage(fileStream))
            {
                var worksheet = package.Workbook.Worksheets[0];

                int rowCount = worksheet.Dimension.End.Row;
                int colCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++)
                {
                    if (worksheet.Cells[row, 1].Text == string.Empty &&
                        worksheet.Cells[row, 2].Text == string.Empty &&
                        worksheet.Cells[row, 3].Text == string.Empty)
                    {
                        continue;
                    }

                    var excelRowData = new ExcelRowData
                    {
                        FullName = worksheet.Cells[row, 1].Text.Trim(),
                        PhoneNumber = worksheet.Cells[row, 2].Text.Trim(),
                        Job = worksheet.Cells[row, 3].Text.Trim()
                    };

                    rows.Add(excelRowData);
                }
            }

            return rows;
        }

    }
}
