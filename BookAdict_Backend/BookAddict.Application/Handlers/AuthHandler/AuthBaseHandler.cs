using DataRepo.Ef;
using BookAddict.Application.Interfaces;

namespace BookAdict.Handlers.AuthHandler
{
    public class AuthBaseHandler
    {
        protected readonly IAuthService _authService;
        protected readonly IUnitOfWork? _unitOfWork;
        public AuthBaseHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public AuthBaseHandler( IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
