using RESTAPI.Models;

namespace RESTAPI.Interfaces
{
    public interface ITokenService
    {

        string CreateToken(AppUser user);
    }
}
