using AutoMapper;
using Library.Data.Dtos;
using Library.Data.Models;

namespace Library.Data
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
