using AutoMapper;
using FileManagement.Application.Dtos;
using FileManagement.Core.Interfaces.Infastructure;
using FileManagement.Data.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FileManagement.Application.Queries
{
    public class GetFileQueryHandler : IRequestHandler<GetFileQuery, FileDto>
    {
        private readonly IBaseRepository<FileDataInfo> _fileDataRepo;
        private readonly IMapper _mapper;

        public GetFileQueryHandler(IBaseRepository<FileDataInfo> fileDataRepo
            , IMapper mapper)
        {
            _fileDataRepo = fileDataRepo;
            _mapper = mapper;
        }

        public async Task<FileDto> Handle(GetFileQuery request, CancellationToken cancellationToken)
        {
            var fileDataInfo = (await _fileDataRepo.GetWhere(x => x.Id == request.ReferenceNumber)).FirstOrDefault();
            return _mapper.Map<FileDto>(fileDataInfo);
        }
    }
}
