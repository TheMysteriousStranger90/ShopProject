using DAL.Entities;

namespace BLL.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}