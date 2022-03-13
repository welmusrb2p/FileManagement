using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FileManagement.Core.Dtos
{
    public class CreateFileDto
    {
        [Required]
       public IFormFile formFile { get; set; }
    }
}
