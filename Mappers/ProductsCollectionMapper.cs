using DomainModel;
using ProductsService.Resources;

namespace ProductsService.Mappers
{
  public class ProductsCollectionMapper
  {
    public IEnumerable<ProductResource> Map(IEnumerable<Product> product)
    {
      var productMapper = new ProductMapper();
      var products = product.Select(p => productMapper.Map(p));

      return products;
    }
  }
}
