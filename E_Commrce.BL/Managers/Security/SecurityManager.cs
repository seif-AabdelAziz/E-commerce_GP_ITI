using E_Commerce.DAL;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace E_Commerce.BL;

public class SecurityManager : ISecurityManager
{
    private readonly UserManager<Customer> userManager;

    public SecurityManager(UserManager<Customer> _userManager)
    {
        userManager = _userManager;
    }

    public IEnumerable<IdentityError>? Register(RegisterDto register)
    {
        var newUser = new Customer
        {
            FirstName = register.FirstName,
            MidName = register.LastName,
            LastName = register.LastName,
            PhoneNumber = register.PhoneNumber,
            Email = register.Email,
            City = register.City,
            Street = register.Street,
            Country = register.Country,
            UserName = register.Email
        };

        var creationResult = userManager.CreateAsync(newUser, register.Password).Result;
        if (!creationResult.Succeeded)
        {
            return creationResult.Errors;

        }

        var claims = new List<Claim> {
            new (ClaimTypes.NameIdentifier,newUser.Id),
            new (ClaimTypes.Role,"Customer")
        };

        var addClaims = userManager.AddClaimsAsync(newUser, claims).Result;
        if (!addClaims.Succeeded)
        {
            return addClaims.Errors;
        }


        return null;
    }
}
