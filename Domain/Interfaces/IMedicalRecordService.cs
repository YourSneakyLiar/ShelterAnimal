using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IMedicalRecordService
    {
        Task<List<MedicalRecord>> GetAll();
        Task<MedicalRecord> GetById(int id);
        Task Create(MedicalRecord model);
        Task Update(MedicalRecord model);
        Task Delete(int id);
    }
}
