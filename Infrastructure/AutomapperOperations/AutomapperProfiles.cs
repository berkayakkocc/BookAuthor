using AutoMapper;
using Core.Dtos.PageDtos.Author;
using Core.Dtos.PageDtos.Book;
using Core.Models.PageEntity;

namespace Infrastructure.AutomapperOperations
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {

            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AuthorNavigationDto>().ReverseMap();
            CreateMap<Author, CreateAuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorDto>().ReverseMap();

            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, BookNavigationDto>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
        }
    }
}
