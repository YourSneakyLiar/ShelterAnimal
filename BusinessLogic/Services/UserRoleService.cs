using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;


namespace BusinessLogic.Services
{
    public class UserRoleService : IUserRoleService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserRoleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserRole>> GetAll()
        {
            return await _repositoryWrapper.UserRole.FindAll();
        }

        public async Task<UserRole> GetById(int id)
        {
            var userRole = await _repositoryWrapper.UserRole
                .FindByCondition(x => x.UserRoleId == id);
            return userRole.First();
        }

        public async Task Create(UserRole model)
        {
            await _repositoryWrapper.UserRole.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(UserRole model)
        {
            _repositoryWrapper.UserRole.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var userRole = await _repositoryWrapper.UserRole
                .FindByCondition(x => x.UserRoleId == id);

            _repositoryWrapper.UserRole.Delete(userRole.First());
            await _repositoryWrapper.Save();
        }
    }
}