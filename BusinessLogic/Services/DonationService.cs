using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class DonationService : IDonationService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public DonationService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Donation>> GetAll()
        {
            return await _repositoryWrapper.Donation.FindAll();
        }

        public async Task<Donation> GetById(int id)
        {
            var donation = await _repositoryWrapper.Donation
                .FindByCondition(x => x.DonationId == id);
            return donation.First();
        }

        public async Task Create(Donation model)
        {
            await _repositoryWrapper.Donation.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Donation model)
        {
            _repositoryWrapper.Donation.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var donation = await _repositoryWrapper.Donation
                .FindByCondition(x => x.DonationId == id);

            _repositoryWrapper.Donation.Delete(donation.First());
            await _repositoryWrapper.Save();
        }
    }
}