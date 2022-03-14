using FileManagement.Core.Interfaces.Infastructure;
using FileManagement.Data.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FileManagement.Application.Commands.Delete
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, bool>
    {
        private readonly IBaseRepository<FileDataInfo> _fileDataRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public DeleteFileCommandHandler(IBaseRepository<FileDataInfo> fileDataRepo
            , IUnitOfWork unitOfWork
            , IConfiguration configuration)
        {
            _fileDataRepo = fileDataRepo;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            bool deleteStatus = false;

            var fileDataInfo = (await _fileDataRepo.GetWhere(x => x.Id == request.ReferenceNumber)).FirstOrDefault();

            if (fileDataInfo != default)
            {
                _fileDataRepo.Delete(fileDataInfo);
                deleteStatus = await _unitOfWork.CommitAsync() > 0;
                if (deleteStatus)
                {
                    var shardFolderPath = _configuration.GetSection("FolderPath").Value;

                    var path = Path.Combine(shardFolderPath, fileDataInfo.Path);

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
            return deleteStatus;
        }
    }
}
