using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IVaccinationService
    {
        Task<List<Vaccination>> GetAll();
        Task<Vaccination> GetById(int id);
        Task Create(Vaccination model);
        Task Update(Vaccination model);
        Task Delete(int id);
    }
}
