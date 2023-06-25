using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL;

public class CategoriesRepo:GenericRepo<Category>, ICategoriesRepo
{

    public readonly E_CommerceContext _context;

    public CategoriesRepo (E_CommerceContext context) : base(context)
    {

        _context = context;

    }









}
