using E_Commerce.DAL;

namespace E_Commerce.BL;

public class UsersManager : IUsersManagers
{

    private readonly IUnitOfWork _unitOfWork;

    public UsersManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #region Delete

    public bool DeleteUser(Guid UserId)
    {
        User? userFromDb = _unitOfWork.UsersRepo.GetById(UserId);
        if (userFromDb != null)

        {
            _unitOfWork.UsersRepo.Delete(userFromDb);
        }

        int numberOfAffectedRows = _unitOfWork.SaveChange();
        return numberOfAffectedRows > 0;
    }
    #endregion

    #region Update User
    public void UpdateUser(UserUpdateDto updateUserDto)
    {

        User userFromDb = _unitOfWork.UsersRepo.GetById(updateUserDto.Id);
        if (userFromDb != null)
        {

            userFromDb.FirstName = updateUserDto.FirstName;
            userFromDb.MidName = updateUserDto.MidName;
            userFromDb.LastName = updateUserDto.LastName;
            userFromDb.PhoneNumber = updateUserDto.PhoneNumber;
            userFromDb.Email = updateUserDto.Email;

        }

    }


    #endregion

    #region Get Users by Id && City

    public List<UserProfileInfoDto>? GetAllUsersByCity(string city, UserRole role)
    {
        List<User>? userFromDb = _unitOfWork.UsersRepo.GetAllUsersByCity(city, role).ToList();
        if (userFromDb == null)
        {
            return null;
        }
        List<UserProfileInfoDto> usertsDto = userFromDb.Select(x => new UserProfileInfoDto
        {
            FirstName = x.FirstName,
            LastName = x.LastName,
            MidName = x.MidName,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,

        }).ToList();


        return usertsDto;
    }

    #endregion


    #region Get By Email

    public UserProfileInfoDto? GetUserByEmail(string email)
    {

        User? userFromDb = _unitOfWork.UsersRepo.GetUserByEmail(email);

        return new UserProfileInfoDto
        {
            FirstName = userFromDb.FirstName,
            LastName = userFromDb.LastName,
            MidName = userFromDb.MidName,
            Role = userFromDb.Role,
            PhoneNumber = userFromDb.PhoneNumber,

        };

    }

    public UserProfileInfoDto GetUserByPhonNumber(string phonenumber)
    {
        User? userFromDb = _unitOfWork.UsersRepo.GetUserByPhonNumber(phonenumber);

        return new UserProfileInfoDto
        {
            FirstName = userFromDb.FirstName,
            LastName = userFromDb.LastName,
            MidName = userFromDb.MidName,
            Role = userFromDb.Role,
            PhoneNumber = userFromDb.PhoneNumber,
            Email = userFromDb.Email
        };
    }

    public List<User> GetAllUsersByRole(UserRole role)
    {
        throw new NotImplementedException();
    }

    List<User> IUsersManagers.GetAllUsersByCity(string city, UserRole role)
    {
        throw new NotImplementedException();
    }

    User? IUsersManagers.GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    User? IUsersManagers.GetUserByPhonNumber(string phonenumber)
    {
        throw new NotImplementedException();
    }







    #endregion



}
