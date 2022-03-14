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

namespace FileManagement.Application.Queries.GetFileContent
{
    public class GetFileContentQueryHandler : IRequestHandler<GetFileContentQuery, byte[]>
    {
        private readonly IBaseRepository<FileDataInfo> _fileDataRepo;
        private readonly IConfiguration _configuration;
        public GetFileContentQueryHandler(IBaseRepository<FileDataInfo> fileDataRepo
            , IConfiguration configuration)
        {
            _fileDataRepo = fileDataRepo;
            _configuration = configuration;
        }
        public async Task<byte[]> Handle(GetFileContentQuery request, CancellationToken cancellationToken)
        {
            var fileDataInfo = (await _fileDataRepo.GetWhere(x => x.Id == request.ReferenceNumber)).FirstOrDefault();

            if (fileDataInfo != default && !string.IsNullOrWhiteSpace(fileDataInfo.Path))
            {
                var shardFolderPath = _configuration.GetSection("FolderPath").Value;

                FileStream fs = new FileStream(Path.Combine(shardFolderPath, fileDataInfo.Path), FileMode.Open, FileAccess.Read);

                int length = Convert.ToInt32(fs.Length);
                byte[] fileContent = new byte[length];
                await fs.ReadAsync(fileContent, 0, length);
                fs.Close();
                return fileContent;
            }
            return default;
        }
    }
}
