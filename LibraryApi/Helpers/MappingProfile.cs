using AutoMapper;
using LibraryApi.Data;
using LibraryApi.Dtos;

namespace LibraryApi.Helpers
{
    public class MappingProfile:Profile 
    {
        public MappingProfile()
        {
            CreateMap<Author, authorsDetailsDto>();
            CreateMap<AuthorsDto, Author>()
                .ForMember(src => src.Image, opt => opt.Ignore());
            CreateMap<Book,BooksDetailsDto>();
            CreateMap<BooksDto, Book>()
                .ForMember(src => src.Poster, opt => opt.Ignore());
        }
    }
}
