using AuthService.Data;
using AuthService.Models;
using AuthService.Models.Dtos;
using AuthService.Service.IService;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Service
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwt _jwtService;
        public UserService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwt jwt)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwt;
        }

        public async Task<bool> AssignUserRoles(string Email, string RoleName)
        {
            var user = await _context.applicationUsers.Where(x=>x.Email.ToLower()== Email.ToLower()).FirstOrDefaultAsync();
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(RoleName).GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleName));
                }
                await _userManager.AddToRoleAsync(user, RoleName);
                return true;
            }
            return false;
        }

      /*  public async Task<ApplicationUser> GetUserById(Guid Id)
        {
            throw new NotImplementedException();
            return await _context.applicationUsers.Where(x => x.Name == Name).FirstOrDefaultAsync();
        }*/

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _context.applicationUsers.Where(x=>x.UserName.ToLower()==loginRequestDto.UserName.ToLower()).FirstOrDefaultAsync();
            var isValid= _userManager.CheckPasswordAsync(user, loginRequestDto.Password).GetAwaiter().GetResult();
            if (!isValid || user==null)
            {
                return new LoginResponseDto();
            }
            var loggeduser = _mapper.Map<UserDto>(user);

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtService.GenerateToken(user, roles);
            var loggedinUser = new LoginResponseDto()
            {
                user = loggeduser,
                token = token
            };
            return loggedinUser;
            
        }

        public async Task<string> RegisterUser(RegisterUserDto userDto)
        {
            try
            {
                var user= _mapper.Map<ApplicationUser>(userDto);
                var result = await _userManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded)
                {
/*
                    if (!_roleManager.RoleExistsAsync(userDto.Role).GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole(userDto.Role));
                    }
                    await _userManager.AddToRoleAsync(user, userDto.Role);*/

                    return string.Empty;
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }
    }
}
