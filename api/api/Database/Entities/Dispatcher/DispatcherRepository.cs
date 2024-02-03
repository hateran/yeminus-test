using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using api.Controllers.Dispatcher.Dtos;

namespace api.Database.Entities.Dispatcher
{
    public class DispatcherRepository: IDispatcherRepository
    {
        private readonly DataContext dbRepository;
        public DispatcherRepository(DataContext _DbRepository)
        {
            dbRepository = _DbRepository;
        }

        public async Task<DispatcherEntity?> GetById(int code)
        {
            return await dbRepository.Dispatcher.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<List<DispatcherEntity>> listAll()
        {
            return await dbRepository.Dispatcher.ToListAsync();
        }

        public async Task<DispatcherEntity?> create(CreateDispatcherDto dispatcher)
        {
            DispatcherEntity entity = new DispatcherEntity()
            {
                NomApels = dispatcher.NomApels,
            };

            EntityEntry<DispatcherEntity> response = await dbRepository.Dispatcher.AddAsync(entity);
            await dbRepository.SaveChangesAsync();

            return await GetById(response.Entity.Code ?? throw new Exception("Error al guardar"));
        }

        public async Task<DispatcherEntity?> update(DispatcherEntity dispatcher)
        {
            EntityEntry<DispatcherEntity> response = dbRepository.Dispatcher.Update(dispatcher);
            await dbRepository.SaveChangesAsync();

            return await GetById(response.Entity.Code ?? throw new Exception("Error al actualizar"));
        }

        public async Task delete(DispatcherEntity dispatcher)
        {
            EntityEntry<DispatcherEntity> response = dbRepository.Dispatcher.Remove(dispatcher);
            await dbRepository.SaveChangesAsync();
        }
    }
}
