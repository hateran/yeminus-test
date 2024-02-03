using System.ComponentModel.DataAnnotations;

namespace api.Controllers.Dispatcher.Dtos
{
    public class CreateDispatcherDto
    {
        [Required]
        public string NomApels { get; set; } = string.Empty;
    }
}
