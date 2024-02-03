using api.Database.Entities.Sell;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Database.Entities.Product
{
    public class ProductEntity
    {
        [Key]
        [Column("Code")]
        public int? Code { get; set; }
        public string Name{ get; set; }
        public int Price { get; set; }

        [InverseProperty(nameof(SellEntity.productRelation))]
        public ICollection<SellEntity> Sells { get; set; }
    }
}
