using Domain;

namespace Application;

public class ProductDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double UnitPrice { get; set; }
    public string ImageUrl { get; set; }
      public int stock { get; set; }
      public int Quantity { get; set; }
  public List<CategoryDto> Categories { get; set; }
  
  

}
