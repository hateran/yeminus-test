using System.ComponentModel.DataAnnotations;

namespace api.Controllers.RegisterMachine.Dtos
{
    public class CreateRegisterMachineDto
    {
        [Required]
        public int Floor { get; set; }
    }
}
