using DomainModel;
using ProductsService.Resources;

namespace ProductsService.Mappers
{
  public class ProductMapper
  {
    public ProductResource Map(Product product)
    {
      return new ProductResource()
      {
        Name = product.Name,
        IsOutOfStock = product.IsOutOfStock,
        Category = product.Category,
        ImageUrl = product.ImageUrl,
        Price = product.Price
      };
    }
    public ProductDto MapDto(ProductResource productResource)
    {
      return new ProductDto()
      {
        Name = productResource.Name,
        IsOutOfStock = productResource.IsOutOfStock,
        Category = productResource.Category,
        ImageUrl = productResource.ImageUrl,
        Price = productResource.Price
      };
    }
  }
}
