using AutoMapper;
using BookAddict.Domain.HelperModels;
using BookAddict.Application.Interfaces;
using BookAddict.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookAddict.Application.DTOS.AuthDtos;

namespace DataRepo.Ef.Services
{

    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly JWTConfig _jwtConfig;
        public AuthService(UserManager<ApplicationUser> userManager, IMapper mapper, IOptions<JWTConfig> jwtConfig, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtConfig = jwtConfig.Value;
            _roleManager = roleManager;

        }

        public async Task<AuthModel> RegisterAsync(RegisterRequestDto registerModel)
        {
            if(await _userManager.FindByEmailAsync(registerModel.Email) is not null)
                return new AuthModel { Message = "Email or Username is already registered " };

            if (await _userManager.FindByNameAsync(registerModel.Username) is not null)
                return new AuthModel { Message = "Email or Username is already registered " };

            var user = _mapper.Map<ApplicationUser>(registerModel);

            var result = await _userManager.CreateAsync(user,registerModel.Password); 
            if (!result.Succeeded)
            {
               return  RegisterErrorHandilerResponse(result);
            }
            await _userManager.AddToRoleAsync(user, "user");
            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthModel(true,user.UserName,user.Email,new List<string> {"User"},
                new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), jwtSecurityToken.ValidTo);

        }
        public async Task<AuthModel> GetTokenasync(TokenRequestDto tokenRequestModel)
        {
            var user = await _userManager.FindByEmailAsync(tokenRequestModel.Email);
            if (user is null || !await _userManager.CheckPasswordAsync(user, tokenRequestModel.Password))
                return (new AuthModel { Message = "Email or Password is incorrect" });

            var jwtSecurityToken = await CreateJwtToken(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            var authModel = new AuthModel(user.Id,true,user,userRoles.ToList(),new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),jwtSecurityToken.ValidTo);
            
            return authModel;
        }

        public async Task<string> AddRoleAsync(AddRoleDto roleDto)
        {
            var user = await _userManager.FindByIdAsync(roleDto.UserId);
            if (user is null || !await _roleManager.RoleExistsAsync(roleDto.Role))
                return ("Invalid user or role");
            if(await _userManager.IsInRoleAsync(user,roleDto.Role))
                return ("user already have this role");
            var result = await _userManager.AddToRoleAsync(user,roleDto.Role);
            return result.Succeeded ? string.Empty : "There was a problem";
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
           return await _userManager.Users.ToListAsync();
        }


        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(_jwtConfig.Issuer,_jwtConfig.Audience,await GetAllRequiredClaimsAsync(user),expires: DateTime.Now.AddDays(_jwtConfig.DurationDays), signingCredentials: signingCredentials);
        }

        private async Task<IEnumerable<Claim>>GetAllRequiredClaimsAsync(ApplicationUser user)
        {
            return new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("uid", user.Id),
            }
            .Union(await _userManager.GetClaimsAsync(user))
            .Union(await GetRolesClaimsAsync(user));
        }



        private async Task<IEnumerable<Claim>> GetRolesClaimsAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>();
            foreach (var role in roles)
                  claims.Add(new Claim("roles",role));
            return claims ;
        }
         

        private AuthModel RegisterErrorHandilerResponse(IdentityResult result)
        {
            var errors = string.Empty;
            foreach (var error in result.Errors)
            {
                errors += $"{error.Description},";
            }
            return  new AuthModel { Message = errors };
        }


    }
}
