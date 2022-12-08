using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}