namespace DomainModel
{
  public class Product
  {
    public int id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public bool IsOutOfStock { get; set; }
    public string ImageUrl { get; set; }
  }
}
