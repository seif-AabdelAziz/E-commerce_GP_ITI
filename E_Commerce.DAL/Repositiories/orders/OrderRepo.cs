

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

        public Order? GetOrderDetails(Guid id)  
        {
            return _context.Set<Order>().Include(o => o.OrderProducts).ThenInclude(o => o.Product)
                                        .FirstOrDefault(o => o.Id == id);
        }

        public Order? GetOrderProducts(Guid id)
        {
            return _context.Set<Order>().Include(o=>o.OrderProducts).ThenInclude(o => o.Product)
                                        .FirstOrDefault(o => o.Id == id);
        }

        public Order? GetOrderProductsAndCustomer(Guid id)
        {
            return _context.Set<Order>().Include(o => o.OrderProducts).ThenInclude(op => op.Product)
                                        .Include(o => o.Customer).Where(o => o.Id == id)
                                        .FirstOrDefault();
        }   
    }
}
