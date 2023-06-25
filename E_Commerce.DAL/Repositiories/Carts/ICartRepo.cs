using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL
{
    public interface ICartRepo : IGenericRepo<Cart>
    {
       Cart? GetCartProductByCustomerId(string CustomerId);
    }
}
