using api.Controllers.Dispatcher.Dtos;
using api.Database.Entities.Dispatcher;

namespace api.Controllers.Dispatcher.Services
{
    public class DispatcherService
    {
        private readonly IDispatcherRepository dispatcherRepository;
        public DispatcherService(IDispatcherRepository dispatcherRepository)
        {
            this.dispatcherRepository = dispatcherRepository;
        }

        public async Task<DispatcherEntity?> getById(int id)
        {
            DispatcherEntity? dispatcher = await dispatcherRepository.GetById(id);
            return dispatcher;
        }

        public async Task<List<DispatcherEntity>> ListAll()
        {
            List<DispatcherEntity> dispatchers = await dispatcherRepository.listAll();
            return dispatchers;
        }

        public async Task<DispatcherEntity?> create(CreateDispatcherDto dispatcher)
        {
            DispatcherEntity? dispatcherEntity = await dispatcherRepository.create(dispatcher);
            return dispatcherEntity;
        }

        public async Task<DispatcherEntity?> update(int id, CreateDispatcherDto body)
        {
            DispatcherEntity? dispatcher = await getById(id);
            if (dispatcher == null) { return dispatcher; }
            dispatcher.NomApels = body.NomApels;
            DispatcherEntity? dispatcherEntity = await dispatcherRepository.update(dispatcher);
            return dispatcherEntity;
        }

        public async Task<Boolean> delete(int id)
        {
            DispatcherEntity? dispatcher = await getById(id);
            if (dispatcher == null) { return false; }
            await dispatcherRepository.delete(dispatcher);
            return true;
        }
    }
}
