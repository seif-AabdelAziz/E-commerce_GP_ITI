
namespace E_Commerce.DAL;

public class Customer : User
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

}
