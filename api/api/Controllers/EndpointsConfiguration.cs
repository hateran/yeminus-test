using api.Controllers.Dispatcher.Services;
using api.Controllers.Exercises.Services;
using api.Controllers.Product.Services;
using api.Controllers.RegisterMachine.Services;
using api.Controllers.Sell.Services;

namespace api.Controllers
{
    public class EndpointsConfiguration
    {
        public void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ProductService> ();
            builder.Services.AddScoped<DispatcherService> ();
            builder.Services.AddScoped<RegisterMachineService> ();
            builder.Services.AddScoped<SellService>();
            builder.Services.AddScoped<ExerciseService>();
        }
    }
}
