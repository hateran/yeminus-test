using System.ComponentModel.DataAnnotations;

namespace api.Controllers.Product.Dtos
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; }
    }
}
