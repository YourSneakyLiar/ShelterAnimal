using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;


namespace BusinessLogic.Services
{
    public class SupplyOrderService : ISupplyOrderService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public SupplyOrderService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<SupplyOrder>> GetAll()
        {
            return await _repositoryWrapper.SupplyOrder.FindAll();
        }

        public async Task<SupplyOrder> GetById(int id)
        {
            var supplyOrder = await _repositoryWrapper.SupplyOrder
                .FindByCondition(x => x.OrderId == id);
            return supplyOrder.First();
        }

        public async Task Create(SupplyOrder model)
        {
            await _repositoryWrapper.SupplyOrder.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(SupplyOrder model)
        {
            _repositoryWrapper.SupplyOrder.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var supplyOrder = await _repositoryWrapper.SupplyOrder
                .FindByCondition(x => x.OrderId == id);

            _repositoryWrapper.SupplyOrder.Delete(supplyOrder.First());
            await _repositoryWrapper.Save();
        }
    }
}