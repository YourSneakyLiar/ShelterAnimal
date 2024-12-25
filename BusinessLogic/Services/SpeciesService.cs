using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;


namespace BusinessLogic.Services
{
    public class SpeciesService : ISpeciesService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public SpeciesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Species>> GetAll()
        {
            return await _repositoryWrapper.Species.FindAll();
        }

        public async Task<Species> GetById(int id)
        {
            var species = await _repositoryWrapper.Species
                .FindByCondition(x => x.SpeciesId == id);
            return species.First();
        }

        public async Task Create(Species model)
        {
            await _repositoryWrapper.Species.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Species model)
        {
            _repositoryWrapper.Species.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var species = await _repositoryWrapper.Species
                .FindByCondition(x => x.SpeciesId == id);

            _repositoryWrapper.Species.Delete(species.First());
            await _repositoryWrapper.Save();
        }
    }
}