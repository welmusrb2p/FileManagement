using FileManagement.Application.Dtos;
using MediatR;
using System;

namespace FileManagement.Application.Queries
{
    public class GetFileQuery:IRequest<FileDto>
    {
        public Guid ReferenceNumber { get; set; }
    }
}
