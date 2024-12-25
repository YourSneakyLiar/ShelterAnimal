using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAdopterService
    {
        Task<List<Adopter>> GetAll();
        Task<Adopter> GetById(int id);
        Task Create(Adopter model);
        Task Update(Adopter model);
        Task Delete(int id);
    }
}
