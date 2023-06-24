namespace E_Commerce.DAL;

public class CustomerReview
{

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public string Description { get; set; }
    public int Rate { get; set; }
    public DateTime CreatedTime { get; set; }
}
