using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL;
public class User
{
    public Guid Id { get; set; }

    public FullName FullName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email format is not valid it must be in the form name@example.com")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;

    public UserRole Role { get; set; }

}

