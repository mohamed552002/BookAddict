﻿using AutoMapper;
using BookAdict.Commands.AuthCommands;
using BookAdict.Queries.AuthQueries;
using DataRepository.Core.Dtos;
using DataRepository.Core.Interfaces;
using DataRepository.Core.Models;
using MediatR;

namespace BookAdict.Handlers.AuthHandler
{
    public class GetAllUsersHandler : AuthBaseHandler, IRequestHandler<GetAllUsersRequest, IEnumerable<ApplicationUserDto>>
    {
        private readonly IMapper _mapper;
        public GetAllUsersHandler(IAuthService authService, IMapper mapper) : base(authService)
        {
            _mapper = mapper;
        }
        public async Task<IEnumerable<ApplicationUserDto>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {

            var allUsers = await _authService.GetAllUsers();
            return _mapper.Map<IEnumerable< ApplicationUserDto>>( allUsers);
        }
    }
}
