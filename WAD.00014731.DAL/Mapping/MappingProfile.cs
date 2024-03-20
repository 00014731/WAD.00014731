using static System.Runtime.InteropServices.JavaScript.JSType;
using WAD._00014731.DTOs;
using WAD._00014731.Models;
using AutoMapper;

namespace WAD._00014731.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Activity, ActivityDto>().ReverseMap();

                
        }
    }
}
