using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL;
    public interface IUsersRepo : IGenericRepo<User>
    {
        List<User>? GetAllUsersByRole(UserRole role);

    }

