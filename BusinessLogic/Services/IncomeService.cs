using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;


namespace BusinessLogic.Services
{
    public class IncomeService : IIncomeService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public IncomeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Income>> GetAll()
        {
            return await _repositoryWrapper.Income.FindAll();
        }

        public async Task<Income> GetById(int id)
        {
            var income = await _repositoryWrapper.Income
                .FindByCondition(x => x.IncomeId == id);
            return income.First();
        }

        public async Task Create(Income model)
        {
            await _repositoryWrapper.Income.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Income model)
        {
            _repositoryWrapper.Income.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var income = await _repositoryWrapper.Income
                .FindByCondition(x => x.IncomeId == id);

            _repositoryWrapper.Income.Delete(income.First());
            await _repositoryWrapper.Save();
        }
    }
}