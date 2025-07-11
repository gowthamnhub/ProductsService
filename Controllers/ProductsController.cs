using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Filters;
using ProductsService.Mappers;
using ProductsService.Resources;

namespace ProductsService.Controllers
{
  [ApiController]
  //[LoggingFilter]
  public class ProductsController : ControllerBase
  {
    [HttpGet]
    [Route("~/api/v1/products")]
    public ActionResult<IEnumerable<ProductResource>> GetProducts()
    {
      var productService = new ProductService();
      var products = productService.GetAllProducts();
      var productsResource = new ProductsCollectionMapper().Map(products);

      return Ok(productsResource);
    }

    [HttpGet]
    [Route("~/api/v1/products/{id}")]
    public ActionResult<ProductResource> GetProduct(int id)
    {
      var productService = new ProductService();
      var product = productService.GetProductById(id);
      if (product == null)
        return NotFound("Product Id not found");
      var productResource = new ProductMapper().Map(product);

      return Ok(productResource);
    }

    [HttpPost]
    [Authorize]
    [Route("~/api/v1/products")]
    public ActionResult<ProductResource> AddProduct(ProductResource productResource)
    {
      var productService = new ProductService();
      var productDto = new ProductMapper().MapDto(productResource);

      var product = productService.AddProduct(productDto);

      var newProductResource = new ProductMapper().Map(product);
      return Ok(newProductResource);
    }
    [HttpPut]
    [Authorize]
    [Route("~/api/v1/products/{id}")]
    public ActionResult<ProductResource> UpdateProduct(int id, ProductResource productResource)
    {
      var productService = new ProductService();
      var productDto = new ProductMapper().MapDto(productResource);

      var product = productService.UpdateProduct(id, productDto);

      var actualProduct = new ProductMapper().Map(product);
      return Ok(actualProduct);
    }
    [HttpDelete]
    [Authorize]
    [Route("~/api/v1/products/{id}")]
    public ActionResult<ProductResource> DeleteProduct(int id)
    {
      var productService = new ProductService();

      var product = productService.DeleteProduct(id);

      var actualProduct = new ProductMapper().Map(product);
      return Ok(actualProduct);
    }
  }
}
