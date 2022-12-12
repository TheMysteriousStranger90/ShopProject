using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ShopProjectContext _context;
        
        public BasketRepository(ShopProjectContext context)
        {
            _context = context;
        }
        
        public Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteBasketAsync(string basketId)
        {
            throw new System.NotImplementedException();
        }
    }
}