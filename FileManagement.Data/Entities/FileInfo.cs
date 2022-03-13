using System;

namespace FileManagement.Data.Entities
{
    public class FileDataInfo: BaseEntity<Guid>
    {
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string ContentType { get; set; }
        public string Path { get; set; }
    }
}
