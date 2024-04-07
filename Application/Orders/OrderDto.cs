

namespace Application.Orders;

public class OrderDto
{
 public List<OrderDetailDto> Items { get; set; }
 public int UserId { get; set; }

 public int id { get; set; }
 public string OrderDate { get; set; }

 public double  TotalInvoice { get; set; }
public double TotalProducts { get; set; }
}
