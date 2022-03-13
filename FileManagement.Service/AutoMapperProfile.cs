using AutoMapper;
using FileManagement.Core.Dtos;
using FileManagement.Data.Entities;

namespace FileManagement
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FileDataInfo, FileDto>()
                .ForMember(dest => dest.ReferenceNumber, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<FileDataInfo, CreateFileDto>().ReverseMap();

        }

    }
}
