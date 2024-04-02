using api.Controllers.RegisterMachine.Dtos;
using api.Database.Entities.RegisterMachine;

namespace api.Controllers.RegisterMachine.Services
{
    public class RegisterMachineService
    {
        private readonly IRegisterMachineRepository registerMachineRepository;
        public RegisterMachineService(IRegisterMachineRepository registerMachineRepository)
        {
            this.registerMachineRepository = registerMachineRepository;
        }

        public async Task<RegisterMachineEntity?> getById(int id)
        {
            RegisterMachineEntity? registerMachine = await registerMachineRepository.GetById(id);
            return registerMachine;
        }

        public async Task<List<RegisterMachineEntity>> ListAll()
        {
            List<RegisterMachineEntity> registerMachines = await registerMachineRepository.listAll();
            return registerMachines;
        }

        public async Task<RegisterMachineEntity?> create(CreateRegisterMachineDto registerMachine)
        {
            RegisterMachineEntity? registerMachineEntity = await registerMachineRepository.create(registerMachine);
            return registerMachineEntity;
        }

        public async Task<RegisterMachineEntity?> update(int id, CreateRegisterMachineDto body)
        {
            RegisterMachineEntity? registerMachine = await getById(id);
            if (registerMachine == null) { return registerMachine; }
            registerMachine.Floor = body.Floor;
            RegisterMachineEntity? registerMachineEntity = await registerMachineRepository.update(registerMachine);
            return registerMachineEntity;
        }

        public async Task<Boolean> delete(int id)
        {
            RegisterMachineEntity? registerMachine = await getById(id);
            if (registerMachine == null) { return false; }
            await registerMachineRepository.delete(registerMachine);
            return true;
        }
    }
}
