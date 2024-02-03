using System.ComponentModel.DataAnnotations;

namespace api.Controllers.Sell.Dtos
{
    public class CreateSellDto
    {
        [Required]
        public int Dispatcher { get; set; }
        [Required]
        public int Product { get; set; }
        [Required]
        public int Machine { get; set; }
    }
}
