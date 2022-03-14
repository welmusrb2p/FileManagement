using AutoMapper;
using FileManagement.Core.Interfaces.Infastructure;
using FileManagement.Data.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileManagement.Application.Commands
{
    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, Guid>
    {
        private readonly IBaseRepository<FileDataInfo> _fileDataRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public CreateFileCommandHandler(IBaseRepository<FileDataInfo> fileDataRepo
            , IUnitOfWork unitOfWork
            , IConfiguration configuration)
        {
            _fileDataRepo = fileDataRepo;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<Guid> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            
            var shardFolderPath = _configuration.GetSection("FolderPath").Value;

            string uniqueFileName = GetUniqueFileName(request.FormFile.FileName);

            string filePath = Path.Combine(shardFolderPath, uniqueFileName);

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await request.FormFile.CopyToAsync(fileStream);
            }

            var fileDataInfo = new FileDataInfo
            {
                FileName = request.FormFile.FileName,
                ContentType = request.FormFile.ContentType,
                FileSize = (int)request.FormFile.Length / 1024,
                Path = uniqueFileName
            };

            var result = await _fileDataRepo.Add(fileDataInfo);

            await _unitOfWork.CommitAsync();

            return result.Id;
        }

        private string GetUniqueFileName(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName);

            string newFileName =
                string.Format("{0}-{1}{2}"
                , Guid.NewGuid().ToString()
                , DateTime.Now.ToString("yyyyMMddHHmmssffff")
                , fileExtension
                );

            return newFileName;
        }
    }
}
