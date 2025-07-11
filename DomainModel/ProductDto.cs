namespace DomainModel;

public class ProductDto
{
  public string Name { get; set; }
  public bool IsOutOfStock { get; set; }
  public string Category { get; set; }
  public string ImageUrl { get; set; }
  public decimal Price { get; set; }
}