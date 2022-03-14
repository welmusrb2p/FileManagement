using AutoMapper;
using FileManagement.Application.Mappings;
using FileManagement.Data.Entities;
using System;

namespace FileManagement.Application.Queries.GetFile
{
    public class FileDto :IMapFrom<FileDataInfo>
    {
        public Guid ReferenceNumber { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string ContentType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FileDataInfo, FileDto>()
                .ForMember(d => d.ReferenceNumber, otp => otp.MapFrom(s => s.Id));
        }
    }
}
