using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;


namespace BusinessLogic.Services
{
    public class VolunteerService : IVolunteerService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public VolunteerService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Volunteer>> GetAll()
        {
            return await _repositoryWrapper.Volunteer.FindAll();
        }

        public async Task<Volunteer> GetById(int id)
        {
            var volunteer = await _repositoryWrapper.Volunteer
                .FindByCondition(x => x.VolunteerId == id);
            return volunteer.First();
        }

        public async Task Create(Volunteer model)
        {
            await _repositoryWrapper.Volunteer.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Volunteer model)
        {
            _repositoryWrapper.Volunteer.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var volunteer = await _repositoryWrapper.Volunteer
                .FindByCondition(x => x.VolunteerId == id);

            _repositoryWrapper.Volunteer.Delete(volunteer.First());
            await _repositoryWrapper.Save();
        }
    }
}