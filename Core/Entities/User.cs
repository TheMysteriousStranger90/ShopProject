using System.Collections.Generic;
using Core.Entities.OrderAggregate;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}