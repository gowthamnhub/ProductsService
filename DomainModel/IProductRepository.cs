
namespace DomainModel
{
  public interface IProductRepository
  {
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int id);
    Product AddProduct(Product product);
    Product UpdateProduct(int id, Product product);
    Product DeleteProduct(int id);

  }
}
