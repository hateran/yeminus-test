using api.Database.Entities.Dispatcher;
using api.Database.Entities.Product;
using api.Database.Entities.RegisterMachine;
using api.Database.Entities.Sell;

namespace api.Database.Entities
{
    public class ConfigureServices
    {
        public void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IDispatcherRepository, DispatcherRepository>();
            builder.Services.AddScoped<IRegisterMachineRepository, RegisterMachineRepository>();
            builder.Services.AddScoped<ISellRepository, SellRepository>();
        }
    }
}
