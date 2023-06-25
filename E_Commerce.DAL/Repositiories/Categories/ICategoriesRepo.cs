using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL;

public interface ICategoriesRepo:IGenericRepo<Category>
{


    IEnumerable<Product> GetProductsForCategory (Guid productId);
    IEnumerable<Category> GetSubCategories (Guid SubCategoriesId);
    IEnumerable<Category> GetParentCategories(Guid ParentCategories);



}
