namespace DomainModel;

public class ProductFactory
{
  public static Product CreateProduct(ProductDto productDto)
  {
    return new Product
    {
      Name = productDto.Name,
      Category = productDto.Category,
      IsOutOfStock = productDto.IsOutOfStock,
      Price = productDto.Price
    };
  }
}