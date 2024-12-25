using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAdoptionService
    {
        Task<List<Adoption>> GetAll();
        Task<Adoption> GetById(int id);
        Task Create(Adoption model);
        Task Update(Adoption model);
        Task Delete(int id);
    }
}
