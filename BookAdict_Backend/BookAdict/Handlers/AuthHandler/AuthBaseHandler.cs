using DataRepository.Core.Interfaces;

namespace BookAdict.Handlers.AuthHandler
{
    public class AuthBaseHandler
    {
        protected readonly IAuthService _authService;

        public AuthBaseHandler(IAuthService authService)
        {
            _authService = authService;
        }
    }
}
