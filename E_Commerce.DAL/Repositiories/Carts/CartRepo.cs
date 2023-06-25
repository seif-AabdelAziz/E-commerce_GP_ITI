using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL
{
    public class CartRepo : GenericRepo<Cart>, ICartRepo
    {
        private readonly E_CommerceContext _context;
    
        public CartRepo(E_CommerceContext context) : base(context)
        {
            _context = context;
        }
   
        public Cart? GetCartProductByCustomerId(string CustomerId)
        {
            Guid id = new Guid(CustomerId);

            return _context.Carts
            .Include(c => c.Products)
            .FirstOrDefault(c => c.CustomerId == id);
            
        }
    }
}
