using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement.Application.Queries.GetFileContent
{
   public class GetFileContentQuery:IRequest<byte[]>
    {
        public Guid ReferenceNumber { get; set; }
    }
}
