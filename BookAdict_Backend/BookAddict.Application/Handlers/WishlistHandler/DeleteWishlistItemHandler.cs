using AutoMapper;
using BookAddict.Application.Commands.WishlistCommands;
using BookAddict.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Handlers.WishlistHandler
{
    public class DeleteWishlistItemHandler :BaseWishListHandler, IRequestHandler<DeleteWishlistItemRequest, bool>
    {
        public DeleteWishlistItemHandler(IUnitOfWork unitOfWork, IMapper mapper = null) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Handle(DeleteWishlistItemRequest request, CancellationToken cancellationToken)
        {
            if(!await _unitOfWork.WishlistItem.IsWishlistItemExists(request.BookId, request.UserId))
                return false;
            var item = await _unitOfWork.WishlistItem.GetWishlistItemAsync(request.UserId, request.BookId);
            _unitOfWork.WishlistItem.DeleteWishlistItem(item);
            return true;
        }
    }
}
