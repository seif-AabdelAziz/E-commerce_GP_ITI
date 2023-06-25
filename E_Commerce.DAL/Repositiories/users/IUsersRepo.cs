

namespace E_Commerce.DAL;
    public interface IUsersRepo : IGenericRepo<User>
    {
        IEnumerable<User>? GetAllUsersByRole(UserRole role);

    }

