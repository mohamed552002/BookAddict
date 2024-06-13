using AutoMapper;
using BookAddict.Application.Commands.AuthorCommands;
using BookAddict.Application.DTOS.AuthorDtos;
using BookAddict.Application.Interfaces;
using BookAddict.Domain.Models;
using BookAdict.Interfaces;
using MediatR;

namespace BookAddict.Application.Handlers.AuthorHandler
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageServices _imageServices;
        public UpdateAuthorHandler(IUnitOfWork unitOfWork, IMapper mapper, IImageServices imageServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageServices = imageServices;
        }
        public async Task Handle(UpdateAuthorRequest request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Author>(request.AuthorDto);
            author.ImageUrl = _imageServices.EditImage(request.AuthorDto.ImageFile, request.AuthorDto.ImageUrl);
            await _unitOfWork.Author.UpdateAuthorAsync(author);
        }
    }
}
