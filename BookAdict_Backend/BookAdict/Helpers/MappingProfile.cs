using AutoMapper;
using DataRepository.Core.Dtos;
using DataRepository.Core.DTOS.AuthorDtos;
using DataRepository.Core.DTOS.BookDtos;
using DataRepository.Core.DTOS.CategoryDtos;
using DataRepository.Core.Models;

namespace BookAdict.Helpers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>().
                ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(a => a.Author)));
            CreateMap<Book, BookInsertDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AuthorInDto>().ReverseMap();
            //CreateMap<Author, AuthorDto>().ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books.Select(ba => ba.Books)));
            CreateMap<Category, CategoryInDto>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<Books_Authors,AuthorDto>().IncludeMembers(src=>src.Author);
            CreateMap<Books_Authors, BookDto>().IncludeMembers(src=>src.Books);
            CreateMap<ApplicationUser, RegisterRequestDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterRequestDto>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();

            //CreateMap<Book, BookDto>().IncludeMembers(src => src.Authors);
        }
    }
}
