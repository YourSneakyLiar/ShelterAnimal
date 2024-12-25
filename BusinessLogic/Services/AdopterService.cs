using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class AdopterService : IAdopterService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AdopterService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Adopter>> GetAll()
        {
            return await _repositoryWrapper.Adopter.FindAll();
        }

        public async Task<Adopter> GetById(int id)
        {
            var adopter = await _repositoryWrapper.Adopter
                .FindByCondition(x => x.AdopterId == id);
            return adopter.First();
        }

        public async Task Create(Adopter model)
        {
            await _repositoryWrapper.Adopter.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Adopter model)
        {
            _repositoryWrapper.Adopter.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var adopter = await _repositoryWrapper.Adopter
                .FindByCondition(x => x.AdopterId == id);

            _repositoryWrapper.Adopter.Delete(adopter.First());
            await _repositoryWrapper.Save();
        }
    }
}