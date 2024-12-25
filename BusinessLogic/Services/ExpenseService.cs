using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;


namespace BusinessLogic.Services
{
    public class ExpenseService : IExpenseService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ExpenseService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Expense>> GetAll()
        {
            return await _repositoryWrapper.Expense.FindAll();
        }

        public async Task<Expense> GetById(int id)
        {
            var expense = await _repositoryWrapper.Expense
                .FindByCondition(x => x.ExpenseId == id);
            return expense.First();
        }

        public async Task Create(Expense model)
        {
            await _repositoryWrapper.Expense.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Expense model)
        {
            _repositoryWrapper.Expense.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var expense = await _repositoryWrapper.Expense
                .FindByCondition(x => x.ExpenseId == id);

            _repositoryWrapper.Expense.Delete(expense.First());
            await _repositoryWrapper.Save();
        }
    }
}