using AutoMapper;
using BookAddict.Application.Commands.AuthorCommands;
using BookAddict.Application.DTOS.AuthorDtos;
using BookAddict.Application.Interfaces;
using BookAddict.Domain.Models;
using BookAdict.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Handlers.AuthorHandler
{
    public class AddAuthorHandler : IRequestHandler<AddAuthorRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageServices _imageServices;
        public AddAuthorHandler(IUnitOfWork unitOfWork, IMapper mapper, IImageServices imageServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageServices = imageServices;
        }
        public async Task Handle(AddAuthorRequest request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Author>(request.AuthorInDto);
            author.ImageUrl = _imageServices.SetImage(request.AuthorInDto.ImageFile);
            await _unitOfWork.Author.AddAuthorAsync(author);
        }
    }
}
