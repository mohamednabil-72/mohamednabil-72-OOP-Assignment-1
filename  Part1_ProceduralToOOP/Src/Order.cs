namespace Src;

public class Order
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public string Date { get; set; }
    public bool IsPaid { get; set; }
    public List<OrderLine> OrderLines { get; set; }

    public Order(int id, Customer customer, string date)
    {
        Id = id;
        Customer = customer;
        Date = date;
        IsPaid = false;
        OrderLines = new List<OrderLine>();
    }
}