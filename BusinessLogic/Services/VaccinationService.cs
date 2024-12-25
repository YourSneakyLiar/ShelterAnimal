using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class VaccinationService : IVaccinationService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public VaccinationService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Vaccination>> GetAll()
        {
            return await _repositoryWrapper.Vaccination.FindAll();
        }

        public async Task<Vaccination> GetById(int id)
        {
            var vaccination = await _repositoryWrapper.Vaccination
                .FindByCondition(x => x.VaccinationId == id);
            return vaccination.First();
        }

        public async Task Create(Vaccination model)
        {
            await _repositoryWrapper.Vaccination.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Vaccination model)
        {
            _repositoryWrapper.Vaccination.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var vaccination = await _repositoryWrapper.Vaccination
                .FindByCondition(x => x.VaccinationId == id);

            _repositoryWrapper.Vaccination.Delete(vaccination.First());
            await _repositoryWrapper.Save();
        }
    }
}