using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;


namespace BusinessLogic.Services
{
    public class AdoptionService : IAdoptionService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AdoptionService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Adoption>> GetAll()
        {
            return await _repositoryWrapper.Adoption.FindAll();
        }

        public async Task<Adoption> GetById(int id)
        {
            var adoption = await _repositoryWrapper.Adoption
                .FindByCondition(x => x.AdoptionId == id);
            return adoption.First();
        }

        public async Task Create(Adoption model)
        {
            await _repositoryWrapper.Adoption.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Adoption model)
        {
            _repositoryWrapper.Adoption.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var adoption = await _repositoryWrapper.Adoption
                .FindByCondition(x => x.AdoptionId == id);

            _repositoryWrapper.Adoption.Delete(adoption.First());
            await _repositoryWrapper.Save();
        }
    }
}