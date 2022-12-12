using System;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ShopProjectContext _context;
        
        public UnitOfWork(ShopProjectContext context, RoleManager<IdentityRole> _roleManager,
            UserManager<User> _userManager, SignInManager<User> _signInManager)
        {
            _context = context;
            roleManager = _roleManager;
            userManager = _userManager;
            signInManager = _signInManager;
        }
        
        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            throw new System.NotImplementedException();
        }
        
        private IBasketRepository _basketRepository;
        private IProductRepository _productRepository;
        
        public IBasketRepository BasketRepository => _basketRepository ??= new BasketRepository(_context);
        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);
        
        
        private readonly UserManager<User> userManager;

        public UserManager<User> UserManager
        {
            get
            {
                return userManager;
            }
        }

        private readonly SignInManager<User> signInManager;

        public SignInManager<User> SignInManager
        {
            get
            {
                return signInManager;
            }
        }

        private readonly RoleManager<IdentityRole> roleManager;

        public RoleManager<IdentityRole> RoleManager
        {
            get
            {
                return roleManager;
            }
        }
        
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}