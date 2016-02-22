namespace Organizr.Data.Models
{
    using Organizr.Data.Common.Models;

    public class Image : BaseModel<int>
    {
        public new int? Id { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public byte[] Content { get; set; }
    }
}
