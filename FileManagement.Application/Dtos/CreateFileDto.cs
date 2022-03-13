using FileManagement.Application.Mappings;
using FileManagement.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace FileManagement.Application.Dtos
{
    public class CreateFileDto: IMapFrom<FileDataInfo>
    {
       public IFormFile formFile { get; set; }
    }
}
