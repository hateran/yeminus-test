using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using api.Controllers.RegisterMachine.Dtos;

namespace api.Database.Entities.RegisterMachine
{
    public class RegisterMachineRepository: IRegisterMachineRepository
    {
        private readonly DataContext dbRepository;
        public RegisterMachineRepository(DataContext _DbRepository)
        {
            dbRepository = _DbRepository;
        }

        public async Task<RegisterMachineEntity?> GetById(int code)
        {
            return await dbRepository.RegisterMachine.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<List<RegisterMachineEntity>> listAll()
        {
            return await dbRepository.RegisterMachine.ToListAsync();
        }

        public async Task<RegisterMachineEntity?> create(CreateRegisterMachineDto registerMachine)
        {
            RegisterMachineEntity entity = new RegisterMachineEntity()
            {
                Floor = registerMachine.Floor,
            };

            EntityEntry<RegisterMachineEntity> response = await dbRepository.RegisterMachine.AddAsync(entity);
            await dbRepository.SaveChangesAsync();

            return await GetById(response.Entity.Code ?? throw new Exception("Error al guardar"));
        }

        public async Task<RegisterMachineEntity?> update(RegisterMachineEntity registerMachine)
        {
            EntityEntry<RegisterMachineEntity> response = dbRepository.RegisterMachine.Update(registerMachine);
            await dbRepository.SaveChangesAsync();

            return await GetById(response.Entity.Code ?? throw new Exception("Error al actualizar"));
        }

        public async Task delete(RegisterMachineEntity registerMachine)
        {
            EntityEntry<RegisterMachineEntity> response = dbRepository.RegisterMachine.Remove(registerMachine);
            await dbRepository.SaveChangesAsync();
        }
    }
}
