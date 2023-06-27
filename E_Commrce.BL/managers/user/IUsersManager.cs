using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL;

public interface IUsersManager
{

    void RegisterUser(UserRegisterDto registerUserDto);
    void DeleteUser(UserDeleteDto deleteUserDto);

    void EditUser(UserEditDto editUserDto);



}
