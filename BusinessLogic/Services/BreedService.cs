using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class BreedService : IBreedService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BreedService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Breed>> GetAll()
        {
            return await _repositoryWrapper.Breed.FindAll();
        }

        public async Task<Breed> GetById(int id)
        {
            var breed = await _repositoryWrapper.Breed
                .FindByCondition(x => x.BreedId == id);
            return breed.First();
        }

        public async Task Create(Breed model)
        {
            await _repositoryWrapper.Breed.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Breed model)
        {
            _repositoryWrapper.Breed.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var breed = await _repositoryWrapper.Breed
                .FindByCondition(x => x.BreedId == id);

            _repositoryWrapper.Breed.Delete(breed.First());
            await _repositoryWrapper.Save();
        }
    }
}