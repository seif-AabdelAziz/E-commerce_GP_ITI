namespace E_Commerce.DAL;

public class CustomerPhones
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public string PhoneNumer { get; set; }
}
