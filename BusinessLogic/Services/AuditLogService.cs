using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;


namespace BusinessLogic.Services
{
    public class AuditLogService : IAuditLogService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AuditLogService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<AuditLog>> GetAll()
        {
            return await _repositoryWrapper.AuditLog.FindAll();
        }

        public async Task<AuditLog> GetById(int id)
        {
            var auditLog = await _repositoryWrapper.AuditLog
                .FindByCondition(x => x.LogId == id);
            return auditLog.First();
        }

        public async Task Create(AuditLog model)
        {
            await _repositoryWrapper.AuditLog.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(AuditLog model)
        {
            _repositoryWrapper.AuditLog.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var auditLog = await _repositoryWrapper.AuditLog
                .FindByCondition(x => x.LogId == id);

            _repositoryWrapper.AuditLog.Delete(auditLog.First());
            await _repositoryWrapper.Save();
        }
    }
}