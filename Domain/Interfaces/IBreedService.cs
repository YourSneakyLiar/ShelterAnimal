using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IBreedService
    {
        Task<List<Breed>> GetAll();
        Task<Breed> GetById(int id);
        Task Create(Breed model);
        Task Update(Breed model);
        Task Delete(int id);
    }
}
