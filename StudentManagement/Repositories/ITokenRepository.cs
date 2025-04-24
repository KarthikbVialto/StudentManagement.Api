using Microsoft.AspNetCore.Identity;

namespace StudentManagement.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
