using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL;

public class FullName
{
    [Required(ErrorMessage = "First Name is required")]
    [MinLength(3, ErrorMessage = "First Name can't be less than three characters")]
    public string FirstName { get; set; } = string.Empty;


    [Required(ErrorMessage = "Middle Name is required")]
    [MinLength(3, ErrorMessage = "Middle Name can't be less than three characters")]
    public string MidName { get; set; } = string.Empty;


    [Required(ErrorMessage = "Last Name is required")]
    [MinLength(3, ErrorMessage = "Last Name can't be less than three characters")]
    public string LastName { get; set; } = string.Empty;
}
