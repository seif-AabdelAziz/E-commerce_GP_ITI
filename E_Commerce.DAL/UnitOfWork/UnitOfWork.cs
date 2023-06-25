using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL
{
    public class UnitOfWork : IUnitOfWork

    {
        public ICartRepo CartRepo { get; set; }
        private readonly E_CommerceContext _context;

        public UnitOfWork(E_CommerceContext context , ICartRepo cartRepo)
        {
            _context = context;
            CartRepo = cartRepo;
        }
        public int SaveChange()
        {
            return _context.SaveChanges();
        }
    }
}
