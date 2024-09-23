namespace SheetList.Web.API.Models
{
    public class FileMetadata
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
        public string BlobUri { get; set; }
        public DateTime UploadedDate { get; set; }
    }
}
