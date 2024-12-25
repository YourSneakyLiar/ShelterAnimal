using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IIncomeService
    {
        Task<List<Income>> GetAll();
        Task<Income> GetById(int id);
        Task Create(Income model);
        Task Update(Income model);
        Task Delete(int id);
    }
}
