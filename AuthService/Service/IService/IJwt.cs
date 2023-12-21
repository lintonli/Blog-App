using AuthService.Models;

namespace AuthService.Service.IService
{
    public interface IJwt
    {
        string GenerateToken(ApplicationUser user, IEnumerable<string> Roles);
    }
}
