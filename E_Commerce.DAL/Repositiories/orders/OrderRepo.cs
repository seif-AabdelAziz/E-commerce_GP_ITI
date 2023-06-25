using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL
{
    public class OrderRepo : GenericRepo<Order>, IOrderRepo
    {
        private readonly E_CommerceContext _context;
        public OrderRepo(E_CommerceContext context) : base(context)
        {
            _context=context;
        }

        public Customer? GetCustomerByOrderId(Guid id)
        {
            return _context.Set<Order>().Where(o => o.Id == id).Select(o => o.Customer).FirstOrDefault();
        }

        public List<OrderProduct> GetOrderDetails(Guid id)
        {
            return _context.Set<OrderProduct>().Include(op => op.Product).Where(op => op.OrderId == id).ToList();
        }

        public List<OrderProduct> GetOrderProducts(Guid id)
        {
            return _context.Set<OrderProduct>().Where(op => op.OrderId == id).ToList();
        }

        public Order? GetOrderProductsAndCustomer(Guid id)
        {
            return _context.Set<Order>().Include(o => o.OrderProducts).ThenInclude(op => op.Product)
                                        .Include(o => o.Customer).Where(o => o.Id == id)
                                        .FirstOrDefault();
        }   
    }
}
