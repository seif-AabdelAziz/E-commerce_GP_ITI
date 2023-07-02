using E_Commerce.DAL;

namespace E_Commerce.BL;

public interface IUsersManager
{

    bool DeleteUser(Guid UserId);
    void UpdateUser(UserUpdateDto editUserDto);
    List<User> GetAllUsersByRole(UserRole role);
    List<User> GetAllUsersByCity(string city, UserRole role);
    User? GetUserByEmail(string email);
    User? GetUserByPhonNumber(string phonenumber);


}
