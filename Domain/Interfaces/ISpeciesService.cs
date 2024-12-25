using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ISpeciesService
    {
        Task<List<Species>> GetAll();
        Task<Species> GetById(int id);
        Task Create(Species model);
        Task Update(Species model);
        Task Delete(int id);
    }
}
