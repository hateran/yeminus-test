using api.Database.Entities.Sell;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Database.Entities.RegisterMachine
{
    public class RegisterMachineEntity
    {
        [Key]
        [Column("Code")]
        public int? Code { get; set; }
        public int Floor { get; set; }

        [InverseProperty(nameof(SellEntity.registerMachineRelation))]
        public ICollection<SellEntity> Sells { get; set; }
    }
}
