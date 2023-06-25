using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly E_CommerceContext _context;

        public UnitOfWork(E_CommerceContext context)
        {
            _context = context;
        }
        public int SaveChange()
        {
            return _context.SaveChanges();
        }
    }
}
