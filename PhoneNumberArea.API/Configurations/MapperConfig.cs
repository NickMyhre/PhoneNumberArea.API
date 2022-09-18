using PhoneNumberArea.API.Data;
using AutoMapper;
using PhoneNumberArea.API.Models.State;
using PhoneNumberArea.API.Models.AreaCode;
using PhoneNumberArea.API.Models.County;

namespace PhoneNumberArea.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<State, CreateStateDto>().ReverseMap();
            CreateMap<State, GetStateDto>().ReverseMap();
            CreateMap<State, UpdateStateDto>().ReverseMap();
            CreateMap<State, StateDto>().ReverseMap();

            CreateMap<AreaCode, CreateAreaCodeDto>().ReverseMap();
            CreateMap<AreaCode, GetAreaCodeDto>().ReverseMap();
            CreateMap<AreaCode, UpdateAreaCodeDto>().ReverseMap();
            CreateMap<AreaCode, AreaCodeDto>().ReverseMap();

            CreateMap<County, CreateCountyDto>().ReverseMap();
            CreateMap<County, UpdateCountyDto>().ReverseMap();
            CreateMap<County, GetCountyDto>().ReverseMap();



        }
        
    }
}
