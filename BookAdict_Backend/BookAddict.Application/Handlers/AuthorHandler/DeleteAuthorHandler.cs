using AutoMapper;
using BookAddict.Application.Commands.AuthorCommands;
using BookAddict.Application.Interfaces;
using BookAdict.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Handlers.AuthorHandler
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageServices _imageServices;
        public DeleteAuthorHandler(IUnitOfWork unitOfWork, IMapper mapper, IImageServices imageServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageServices = imageServices;
        }

        public async Task<bool> Handle(DeleteAuthorRequest request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Author.GetAuthorAsync(request.Id);
            if (author == null)
                return false;
            _imageServices.DeleteImage(author.ImageUrl);
            await _unitOfWork.Author.DeleteAuthorAsync(author);
            return true;
        }
    }
}
