using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAnimalService
    {
        Task<List<Animal>> GetAll();
        Task<Animal> GetById(int id);
        Task Create(Animal model);
        Task Update(Animal model);
        Task Delete(int id);
    }
}
