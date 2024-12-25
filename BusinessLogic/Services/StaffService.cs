using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;


namespace BusinessLogic.Services
{
    public class StaffService : IStaffService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public StaffService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Staff>> GetAll()
        {
            return await _repositoryWrapper.Staff.FindAll();
        }

        public async Task<Staff> GetById(int id)
        {
            var staff = await _repositoryWrapper.Staff
                .FindByCondition(x => x.StaffId == id);
            return staff.First();
        }

        public async Task Create(Staff model)
        {
            await _repositoryWrapper.Staff.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Staff model)
        {
            _repositoryWrapper.Staff.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var staff = await _repositoryWrapper.Staff
                .FindByCondition(x => x.StaffId == id);

            _repositoryWrapper.Staff.Delete(staff.First());
            await _repositoryWrapper.Save();
        }
    }
}