using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace FileManagement.Application.Commands
{
    public class CreateFileCommand:IRequest<Guid>
    {
       public IFormFile FormFile { get; set; }

    }
}
