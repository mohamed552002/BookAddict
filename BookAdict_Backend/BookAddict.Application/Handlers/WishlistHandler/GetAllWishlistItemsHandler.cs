using AutoMapper;
using BookAddict.Application.DTOS.WishlistDtos;
using BookAddict.Application.Interfaces;
using BookAddict.Application.Queries.WishlistQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Handlers.WishlistHandler
{
    public class GetAllWishlistItemsHandler : BaseWishListHandler , IRequestHandler<GetAllWishlistItemsRequest, IEnumerable<GetWishlistItemDto>>
    {
        public GetAllWishlistItemsHandler(IUnitOfWork unitOfWork, IMapper mapper = null) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<GetWishlistItemDto>> Handle(GetAllWishlistItemsRequest request, CancellationToken cancellationToken)
        {
            var wishlistItems =  await _unitOfWork.WishlistItem.GetWishlistItemsAsync(request.UsertId);
            return _mapper.Map<IEnumerable<GetWishlistItemDto>>(wishlistItems);
        }
    }
}
