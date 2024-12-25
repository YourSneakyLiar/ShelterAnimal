using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;


namespace BusinessLogic.Services
{
    public class SupplyService : ISupplyService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public SupplyService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Supply>> GetAll()
        {
            return await _repositoryWrapper.Supply.FindAll();
        }

        public async Task<Supply> GetById(int id)
        {
            var supply = await _repositoryWrapper.Supply
                .FindByCondition(x => x.SupplyId == id);
            return supply.First();
        }

        public async Task Create(Supply model)
        {
            await _repositoryWrapper.Supply.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Supply model)
        {
            _repositoryWrapper.Supply.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var supply = await _repositoryWrapper.Supply
                .FindByCondition(x => x.SupplyId == id);

            _repositoryWrapper.Supply.Delete(supply.First());
            await _repositoryWrapper.Save();
        }
    }
}