//using FileManagement.Data.Entities;
//using FileManagement.Core.Interfaces.Infastructure;
//using FileManagement.Core.Interfaces.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using FileManagement.Core.Dtos;
//using AutoMapper;
//using System.IO;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Configuration;

//namespace FileManagement.Services
//{
//    public class FileService : IFileService
//    {
//        private readonly IBaseRepository<FileDataInfo> _fileDataRepo;
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IMapper _mapper;
//        private readonly IConfiguration _configuration;
//        public FileService(IBaseRepository<FileDataInfo> fileDataRepo
//            , IUnitOfWork unitOfWork
//            , IMapper mapper
//            , IConfiguration configuration)
//        {
//            _fileDataRepo = fileDataRepo;
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//            _configuration = configuration;
//        }


//        public async Task<FileDto> GetFileInfo(Guid referenceNumber)
//        {
//            var fileDataInfo = (await _fileDataRepo.GetWhere(x => x.Id == referenceNumber)).FirstOrDefault();
//            return _mapper.Map<FileDto>(fileDataInfo);
//        }

//        public async Task<byte[]> GetFileContent(Guid referenceNumber)
//        {
//            var fileDataInfo = (await _fileDataRepo.GetWhere(x => x.Id == referenceNumber)).FirstOrDefault();
//            if (fileDataInfo != default && !string.IsNullOrWhiteSpace(fileDataInfo.Path))
//            {
//                FileStream fs = new FileStream(fileDataInfo.Path, FileMode.Open, FileAccess.Read);
//                int length = Convert.ToInt32(fs.Length);
//                byte[] fileContent = new byte[length];
//                await fs.ReadAsync(fileContent, 0, length);
//                fs.Close();
//                return fileContent;
//            }
//            return default;
//        }

//        public async Task<byte[]> GetFileContent(string filePath)
//        {
//            if (!string.IsNullOrWhiteSpace(filePath))
//            {
//                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
//                int length = Convert.ToInt32(fs.Length);
//                byte[] fileContent = new byte[length];
//                await fs.ReadAsync(fileContent, 0, length);
//                fs.Close();
//                return fileContent;
//            }
//            return default;
//        }

//        public async Task<Guid> AddFile(CreateFileDto  createFileDto)
//        {
    //            var shardFolderPath = _configuration.GetSection("FolderPath").Value;

    //            string uniqueFileName = GetUniqueFileName(createFileDto.formFile.FileName);

    //            string filePath = Path.Combine(shardFolderPath, uniqueFileName);

    //            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
    //            {
    //                await createFileDto.formFile.CopyToAsync(fileStream);
    //            }

    //            var fileDataInfo = new FileDataInfo
    //            {
    //                FileName = createFileDto.formFile.FileName,
    //                ContentType = createFileDto.formFile.ContentType,
    //                FileSize = (int)createFileDto.formFile.Length / 1024,
    //                Path = filePath
    //            };

    //            var result = await _fileDataRepo.Add(fileDataInfo);

    //            await _unitOfWork.CommitAsync();

    //            return result.Id;
//        }
//        private string GetUniqueFileName(string fileName)
//        {
//            string fileExtension = Path.GetExtension(fileName);

//            string newFileName =
//                string.Format("{0}-{1}{2}"
//                , Guid.NewGuid().ToString()
//                , DateTime.Now.ToString("yyyyMMddHHmmssffff")
//                , fileExtension
//                );

//            return newFileName;
//        }

//        public async Task<bool> DeleteFile(Guid referenceNumber)
//        {
//            bool deleteStatus = false;

//            var fileDataInfo = (await _fileDataRepo.GetWhere(x => x.Id == referenceNumber)).FirstOrDefault();

//            if (fileDataInfo != default)
//            {
//                _fileDataRepo.Delete(fileDataInfo);
//                deleteStatus = await _unitOfWork.CommitAsync() > 0;
//                if (deleteStatus)
//                {
//                    if (File.Exists(fileDataInfo.Path))
//                    {
//                        File.Delete(fileDataInfo.Path);
//                    }
//                }
//            }
//            return deleteStatus;
//        }

//    }
//}
