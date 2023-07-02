using E_Commerce.DAL;

namespace E_Commerce.BL;

public interface IUsersManagers
{

    public bool DeleteUser(Guid UserId);
    public void UpdateUser(UserUpdateDto editUserDto);
    public List<User> GetAllUsersByRole(UserRole role);
    public  List<User> GetAllUsersByCity(string city, UserRole role);
    public User? GetUserByEmail(string email);
    public User? GetUserByPhonNumber(string phonenumber);


}
