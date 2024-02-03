using api.Controllers.Dispatcher.Dtos;
using api.Controllers.Product.Dtos;
using api.Controllers.RegisterMachine.Dtos;
using api.Database.Entities.Dispatcher;
using api.Database.Entities.Product;
using api.Database.Entities.RegisterMachine;
using AutoMapper;

namespace api.Helpers
{
    public class MappinProfiles : Profile
    {
        public MappinProfiles()
        {
            CreateMap<ProductEntity, ProductResponseDto>();
            CreateMap<ProductResponseDto, ProductEntity>();
            CreateMap<DispatcherEntity, DispatcherResponseDto>();
            CreateMap<DispatcherResponseDto, DispatcherEntity>();
            CreateMap<RegisterMachineEntity, RegisterMachineResponseDto>();
            CreateMap<RegisterMachineResponseDto, RegisterMachineEntity>();
        }
    }
}
