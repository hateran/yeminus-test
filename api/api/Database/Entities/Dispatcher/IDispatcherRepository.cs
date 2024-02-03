using api.Controllers.Dispatcher.Dtos;

namespace api.Database.Entities.Dispatcher
{
    public interface IDispatcherRepository
    {
        public Task<DispatcherEntity?> GetById(int code);
        public Task<List<DispatcherEntity>> listAll();
        public Task<DispatcherEntity?> create(CreateDispatcherDto dispatcher);
        public Task<DispatcherEntity?> update(DispatcherEntity dispatcher);
        public Task delete(DispatcherEntity dispatcher);
    }
}
