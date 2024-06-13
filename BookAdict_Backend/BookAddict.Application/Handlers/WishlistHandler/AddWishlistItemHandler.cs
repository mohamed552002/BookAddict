using BookAddict.Application.Commands.WishlistCommands;
using BookAddict.Application.Interfaces;
using BookAddict.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Handlers.WishlistHandler
{
    public class AddWishlistItemHandler : BaseWishListHandler, IRequestHandler<AddWishlistItemRequest, bool>
    {
        public AddWishlistItemHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<bool> Handle(AddWishlistItemRequest request, CancellationToken cancellationToken)
        {
            if(!_unitOfWork.Books.IsBookExist(request.AddWishlistItemDto.BookId) && !(await _unitOfWork.User.IsUserExist(request.AddWishlistItemDto.UserId)))
                return false;
            //var wishlistItem = _mapper.Map<WishlistItem>(request.AddWishlistItemDto);
            await _unitOfWork.WishlistItem.AddWishlistItemAsync(new WishlistItem() { BookId= request.AddWishlistItemDto.BookId, UserId = request.AddWishlistItemDto.UserId});
            _unitOfWork.ActionOnComplete();
            return true;
        }
    }
}
