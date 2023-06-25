namespace E_Commerce.DAL;

public class UsersRepo : GenericRepo<User>, IUsersRepo
{

    private readonly E_CommerceContext _context;

    public UsersRepo(E_CommerceContext context) : base(context)
    {

        _context = context;

    }

    public List<User>? GetAllUsersByRole(UserRole role)
    {

        return _context.Set<User>().Where(x => x.Role == role).ToList;
            

    }

}
