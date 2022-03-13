using System;

namespace FileManagement.Core.Dtos
{
    public class FileDto
    {
        public Guid ReferenceNumber { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string ContentType { get; set; }
        public string Path { get; set; }
    }
}
