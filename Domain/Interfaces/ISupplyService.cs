using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ISupplyService
    {
        Task<List<Supply>> GetAll();
        Task<Supply> GetById(int id);
        Task Create(Supply model);
        Task Update(Supply model);
        Task Delete(int id);
    }
}
