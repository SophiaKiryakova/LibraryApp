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

            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId));
        }
    }
}
