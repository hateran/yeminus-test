using api.Controllers.RegisterMachine.Dtos;

namespace api.Database.Entities.RegisterMachine
{
    public interface IRegisterMachineRepository
    {
        public Task<RegisterMachineEntity?> GetById(int code);
        public Task<List<RegisterMachineEntity>> listAll();
        public Task<RegisterMachineEntity?> create(CreateRegisterMachineDto registerMachine);
        public Task<RegisterMachineEntity?> update(RegisterMachineEntity registerMachine);
        public Task delete(RegisterMachineEntity product);
    }
}
