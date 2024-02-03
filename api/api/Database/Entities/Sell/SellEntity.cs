using api.Database.Entities.Dispatcher;
using api.Database.Entities.Product;
using api.Database.Entities.RegisterMachine;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Database.Entities.Sell
{
    public class SellEntity
    {
        [Column("Dispatcher")]
        public int Dispatcher { get; set; }
        [Column("Product")]
        public int Product { get; set; }
        [Column("Machine")]
        public int Machine { get; set; }

        [ForeignKey(nameof(Dispatcher))]
        [JsonIgnore]
        public DispatcherEntity dispatcherRelation { get; set; }
        [ForeignKey(nameof(Product))]
        [JsonIgnore]
        public ProductEntity productRelation { get; set; }
        [ForeignKey(nameof(Machine))]
        [JsonIgnore]
        public RegisterMachineEntity registerMachineRelation { get; set; }
    }
}
