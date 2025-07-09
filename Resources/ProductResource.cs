using System.ComponentModel.DataAnnotations;

namespace ProductsService.Resources
{
  public class ProductResource
  {
    [Required] public string Name { get; set; }
    [Required] public decimal Price { get; set; }

    [Required] public string Category { get; set; }
    public bool IsOutOfStock { get; set; }
    public string ImageUrl { get; set; }

  }
}
