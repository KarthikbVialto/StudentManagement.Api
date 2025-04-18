using AutoMapper;
using StudentManagement.Models.Domain;
using StudentManagement.Models.Dto;

namespace StudentManagement.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student,StudentDto>().ReverseMap();
            CreateMap<AddStudentRequestDto, Student>()
                         .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                         .ForMember(dest => dest.RollNo, opt => opt.MapFrom(src => src.RollNo))
                         .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                         .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                         .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                         .ReverseMap();
            CreateMap<DepartmentDto, Department>()
                         .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                         .ForMember(dest => dest.Specialisation, opt => opt.MapFrom(src => src.Specialisation))
                         .ReverseMap();

            CreateMap<AddressDto, Address>()
                         .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                         .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                         .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                         .ForMember(dest => dest.Zip, opt => opt.MapFrom(src => src.Zip))
                         .ReverseMap();

            CreateMap<UpdateStudentRequestDto,Student>()
                         .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                         .ForMember(dest => dest.RollNo, opt => opt.MapFrom(src => src.RollNo))
                         .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                         .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                         .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                         .ReverseMap();

        }

    }
}
