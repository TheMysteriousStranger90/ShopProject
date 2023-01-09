using System;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : BaseEntity;
        //IBasketRepository BasketRepository { get; }
        IProductRepository ProductRepository { get; }
        UserManager<User> UserManager { get; }
        SignInManager<User> SignInManager { get; }
        RoleManager<IdentityRole> RoleManager { get; }
        Task<int> SaveAsync();
    }
}