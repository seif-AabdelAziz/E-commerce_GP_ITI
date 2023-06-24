
namespace E_Commerce.DAL;

public class Customer : User
{

    public Address Address { get; set; }
    public PaymentCardInfo PaymentCardInfo { get; set; }

    public WishList WishList { get; set; }

    public List<CustomerPhones> Phones { get; set; }
    public List<CustomerReview> Reviews { get; set; }

}
