namespace Domain;

public class Order
{
public int Id { get; set; }
public DateTime Date { get; set; }
public Customer User { get; set; }
public OrderDetails Details { get; set; }

}
