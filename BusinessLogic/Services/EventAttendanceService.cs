using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;


namespace BusinessLogic.Services
{
    public class EventAttendanceService : IEventAttendanceService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public EventAttendanceService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<EventAttendance>> GetAll()
        {
            return await _repositoryWrapper.EventAttendance.FindAll();
        }

        public async Task<EventAttendance> GetById(int id)
        {
            var eventAttendance = await _repositoryWrapper.EventAttendance
                .FindByCondition(x => x.AttendanceId == id);
            return eventAttendance.First();
        }

        public async Task Create(EventAttendance model)
        {
            await _repositoryWrapper.EventAttendance.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(EventAttendance model)
        {
            _repositoryWrapper.EventAttendance.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var eventAttendance = await _repositoryWrapper.EventAttendance
                .FindByCondition(x => x.AttendanceId == id);

            _repositoryWrapper.EventAttendance.Delete(eventAttendance.First());
            await _repositoryWrapper.Save();
        }
    }
}