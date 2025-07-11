
namespace DomainModel
{
  public class ProductRepository: IProductRepository
  {
    private List<Product> products = new List<Product>
    {
      new()
      {
        id = 1, Name = "Product 1", Price = 10.99m, Category = "Category A", IsOutOfStock = false,
        ImageUrl = "https://example.com/product1.jpg"
      },
      new()
      {
        id = 2, Name = "Product 2", Price = 15.49m, Category = "Category B", IsOutOfStock = true,
        ImageUrl = "https://example.com/product2.jpg"
      },
      new()
      {
        id = 3, Name = "Product 3", Price = 7.99m, Category = "Category A", IsOutOfStock = false,
        ImageUrl = "https://example.com/product3.jpg"
      }
    };
    public IEnumerable<Product> GetAllProducts()
    {
      return products;
    }

    public Product GetProductById(int id)
    {
      if (id <= 0)
      {
        throw new ArgumentException("Product ID must be greater than zero.", nameof(id));
      }
      return products.FirstOrDefault(p => p.id == id);
    }

    public Product AddProduct(Product product)
    {
      var lastProduct = products.LastOrDefault();
      if (lastProduct == null)
      {
        product.id = 1;
      }
      else
      {
        product.id = lastProduct.id + 1;
      }
      products.Add(product);
      return product;
    }
    public Product UpdateProduct(int id, Product product)
    {
      var targetProduct = products.FirstOrDefault(p => p.id == id);
      if (targetProduct != null)
      {
        targetProduct.Name = product.Name;
        targetProduct.Category = product.Category;
        targetProduct.IsOutOfStock = product.IsOutOfStock;
        targetProduct.Price = product.Price;
        targetProduct.ImageUrl = product.ImageUrl;
      }
      else
      {
        throw new KeyNotFoundException($"Product with id {id} not found.");
      }

      return targetProduct;
    }

    public Product DeleteProduct(int id)
    {
      var targetProduct = products.FirstOrDefault(p => p.id == id);
      if (targetProduct != null)
      {
        products.Remove(targetProduct);
      }
      else
      {
        throw new KeyNotFoundException($"Product with id {id} not found.");
      }

      return targetProduct;
    }
  }
}
