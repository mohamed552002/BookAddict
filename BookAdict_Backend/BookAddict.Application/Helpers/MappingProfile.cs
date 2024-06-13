using AutoMapper;
using BookAddict.Application.DTOS.AuthorDtos;
using BookAddict.Application.DTOS.BookDtos;
using BookAdict.Application.DTOS.CategoryDtos;
using BookAddict.Domain.Models;
using BookAddict.Application.DTOS.CategoryDtos;
using BookAddict.Application.DTOS.CartDtos;
using BookAddict.Application.DTOS.AuthDtos;
using BookAddict.Application.DTOS.UserDtos;
using BookAddict.Application.DTOS.OrderAndPaymentDtos;
using BookAddict.Application.DTOS.WishlistDtos;

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
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Books_Authors,AuthorDto>().IncludeMembers(src=>src.Author);
            CreateMap<Books_Authors, BookDto>().IncludeMembers(src=>src.Books);
            CreateMap<ApplicationUser, RegisterRequestDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterRequestDto>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUser, AuthModel>().ReverseMap();
            CreateMap<OrderItem,OrderItemDto>().ReverseMap();
            CreateMap<OrderItem,CartItem>().ReverseMap();
            //CreateMap<Book, BookDto>().IncludeMembers(src => src.Authors);

            // Wishlist
            CreateMap<WishlistItem, AddWishlistItemDto>();
            CreateMap<WishlistItem, GetWishlistItemDto>();
            
        }
    }
}
