using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;


namespace BusinessLogic.Services
{
    public class EventService : IEventService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public EventService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Event>> GetAll()
        {
            return await _repositoryWrapper.Event.FindAll();
        }

        public async Task<Event> GetById(int id)
        {
            var @event = await _repositoryWrapper.Event
                .FindByCondition(x => x.EventId == id);
            return @event.First();
        }

        public async Task Create(Event model)
        {
            await _repositoryWrapper.Event.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Event model)
        {
            _repositoryWrapper.Event.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var @event = await _repositoryWrapper.Event
                .FindByCondition(x => x.EventId == id);

            _repositoryWrapper.Event.Delete(@event.First());
            await _repositoryWrapper.Save();
        }
    }
}