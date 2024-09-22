using Xeptions;

namespace SheetList.Web.API.Models.Exceptions
{
    public class NotSupportedFileException : Xeption
    {
        public NotSupportedFileException()
          : base(message: "File type is not supported. Try again")
        { }
    }
}