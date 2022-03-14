using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement.Application.Commands.Delete
{
    public class DeleteFileCommand :IRequest<bool>
    {
        public Guid ReferenceNumber { get; set; }
    }
}
