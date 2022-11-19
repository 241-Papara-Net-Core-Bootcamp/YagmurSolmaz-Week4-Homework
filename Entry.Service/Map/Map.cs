using AutoMapper;
using Entry.Data.Dtos;
using Entry.Domain.Entities;

namespace Entry.Service.Map
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<EntryEntity, EntryDto>()
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.SurName))
            .ForMember(dest => dest.Entry, opt => opt.MapFrom(src => src.Entry))
            .ReverseMap();
        }
    }
}

