using Microsoft.AspNetCore.Components.Forms;

namespace SheetList.Web.Models.DTOs
{
    public class GetAllFileDTO
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string BlobPath { get; set; }
    }
}