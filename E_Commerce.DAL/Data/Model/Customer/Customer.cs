﻿
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL;

public class Customer 
{

    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public Countries Country { get; set; }

    public WishList? WishList { get; set; }
    public string NameOnCard { get; set; } = string.Empty;
    public int CardNumber { get; set; }
    public DateTime ExpireDate { get; set; }

    public List<CustomerPhones> Phones { get; set; } = new List<CustomerPhones>();
    public List<CustomerReview>? Reviews { get; set; }


    //User
    public Guid Id { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    [MinLength(3, ErrorMessage = "First Name can't be less than three characters")]
    public string FirstName { get; set; } = string.Empty;


    [Required(ErrorMessage = "Middle Name is required")]
    [MinLength(3, ErrorMessage = "Middle Name can't be less than three characters")]
    public string MidName { get; set; } = string.Empty;


    [Required(ErrorMessage = "Last Name is required")]
    [MinLength(3, ErrorMessage = "Last Name can't be less than three characters")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email format is not valid it must be in the form name@example.com")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;

    public UserRole Role { get; set; }
}
