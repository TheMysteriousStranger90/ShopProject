using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _unitOfWork.UserManager.Users.AsNoTracking()
                .ToListAsync();
            if (users == null) throw new ShopProjectException($"Not found!");
            
            var result = _mapper.Map<IEnumerable<UserDto>>(users);
            return result;
        }
        
        public async Task<UserDto> GetByIdAsync(string id)
        {
            var user =  await _unitOfWork.UserManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            
            if (user == null) throw new ShopProjectException("This user wasn't found");
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<string>> GetUserRoles(string email)
        {
            var user = await _unitOfWork.UserManager.FindByEmailAsync(email);
            if (user == null) throw new ShopProjectException("User with such email doesn't exist");
            
            return await _unitOfWork.UserManager.GetRolesAsync(user);
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _unitOfWork.UserManager.FindByEmailAsync(email);
            if (user == null) throw new ShopProjectException($"Not found!");
            
            var result = _mapper.Map<UserDto>(user);
            return result;
        }
        
        public async Task SetUserRoleAsync(UserRoleDto userRoleDto)
        {
            var user = await _unitOfWork.UserManager.Users.FirstOrDefaultAsync(u => u.Id == userRoleDto.Id);

            if (user == null) throw new ShopProjectException("User not found");
            if (!string.Equals(userRoleDto.Role, "User")) throw new ShopProjectException("User role is invalid");
            
            var userRoles = await _unitOfWork.UserManager.GetRolesAsync(user);
            await _unitOfWork.UserManager.RemoveFromRolesAsync(user ,userRoles);
            await _unitOfWork.UserManager.AddToRoleAsync(user, userRoleDto.Role);

            var result = await _unitOfWork.UserManager.UpdateAsync(user);
            
            if (!result.Succeeded) throw new ShopProjectException(result.Errors?.FirstOrDefault()?.Description);
        }
    }
}