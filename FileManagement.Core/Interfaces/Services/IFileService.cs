using FileManagement.Core.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileManagement.Core.Interfaces.Services
{
    public interface IFileService
    {
        Task<FileDto> GetFileInfo(Guid referenceNumber);
        Task<byte[]> GetFileContent(Guid referenceNumber);
        Task<byte[]> GetFileContent(string filePath);
        Task<Guid> AddFile(CreateFileDto createFileDto);
        Task<bool> DeleteFile(Guid referenceNumber);
    }
}
