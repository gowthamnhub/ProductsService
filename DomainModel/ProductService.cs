namespace DomainModel
{
  public class ProductService
  {
    private IProductRepository productRepository;

    public ProductService()
    {
      productRepository = new ProductRepository();
    }
    public IEnumerable<Product> GetAllProducts()
    {
      return productRepository.GetAllProducts();
    }
    public Product GetProductById(int id)
    {
      return productRepository.GetProductById(id);
    }

    public Product AddProduct(ProductDto productDto)
    {
      var product = ProductFactory.CreateProduct(productDto);
      return productRepository.AddProduct(product);
    }
    public Product UpdateProduct(int id, ProductDto productDto)
    {
      var product = ProductFactory.CreateProduct(productDto);
      return productRepository.UpdateProduct(id, product);
    }
    public Product DeleteProduct(int id)
    {
      return productRepository.DeleteProduct(id);
    }
  }
}
