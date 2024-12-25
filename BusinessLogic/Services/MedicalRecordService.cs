using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;


namespace BusinessLogic.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MedicalRecordService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<MedicalRecord>> GetAll()
        {
            return await _repositoryWrapper.MedicalRecord.FindAll();
        }

        public async Task<MedicalRecord> GetById(int id)
        {
            var medicalRecord = await _repositoryWrapper.MedicalRecord
                .FindByCondition(x => x.RecordId == id);
            return medicalRecord.First();
        }

        public async Task Create(MedicalRecord model)
        {
            await _repositoryWrapper.MedicalRecord.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(MedicalRecord model)
        {
            _repositoryWrapper.MedicalRecord.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var medicalRecord = await _repositoryWrapper.MedicalRecord
                .FindByCondition(x => x.RecordId == id);

            _repositoryWrapper.MedicalRecord.Delete(medicalRecord.First());
            await _repositoryWrapper.Save();
        }
    }
}