using api.Database.Entities.Sell;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Database.Entities.Dispatcher
{
    public class DispatcherEntity
    {
        [Key]
        [Column("Code")]
        public int? Code { get; set; }
        public string NomApels { get; set; }

        [InverseProperty(nameof(SellEntity.dispatcherRelation))]
        public ICollection<SellEntity> Sells { get; set; }
    }
}
