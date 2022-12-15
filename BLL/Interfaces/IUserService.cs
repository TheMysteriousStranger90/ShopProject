using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<IEnumerable<string>> GetUserRoles(string email);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<UserDto> GetByIdAsync(string id);
        Task SetUserRoleAsync(UserRoleDto userRoleDto);
    }
}