using AuthService.Models;
using AuthService.Models.Dtos;

namespace AuthService.Service.IService
{
    public interface IUser
    {
        Task<string> RegisterUser(RegisterUserDto userDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignUserRoles(string Email, string RoleName);
       /* Task<ApplicationUser> GetUserById(Guid Id);*/
    }
}
