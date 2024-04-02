using api.Database.Entities.Product;
using api.Database.Entities.Sell;

namespace api.Controllers.Sell.Dtos
{
    public class SellResponseDto : CreateSellDto
    {
    }

    public class TotalSellByProductResponseDto
    {
        public int Total { get; set; }
        public int? Code { get; set; }
        public string Name { get; set; }
    }

    public class HigherSellerResponseDto
    {
        public int Code { get; set; }
        public string NomApels { get; set; }
    }

    public class AllSelledProductsResponseDto 
    { 
        public int Dispatcher {  get; set; }
        public int Machine { get; set; }
        public int Product { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class TotalSellsByFloor
    {
        public int Floor { get; set; }
        public int totalValue { get; set; }
    }
}
