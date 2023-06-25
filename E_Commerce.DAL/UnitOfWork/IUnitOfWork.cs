using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL
{
    public interface IUnitOfWork 
    {

        public ICustomerRepo CustomerRepo { get;  }
        public ICartRepo CartRepo { get;  }
        public ICategoriesRepo CategoriesRepo { get; }
        public ICustomerReviewRepo CustomerReviewRepo { get; }
        public IOrderRepo OrderRepo { get; }
        public IProductsRepo ProductsRepo { get;  }
        public IUsersRepo UsersRepo { get;  }
        public IWishListRepo WishListRepo { get; }
        int SaveChange();
    }
}
