using Microsoft.AspNetCore.Components.Forms;

namespace SheetList.Web.Models
{
    public class FileData
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public IBrowserFile BlobPath { get; set; }
    }
}
