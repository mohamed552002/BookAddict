using DataRepository.Core.Interfaces;

namespace BookAdict.Handlers.CartHandler
{
    public class BaseCartHandler
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseCartHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
