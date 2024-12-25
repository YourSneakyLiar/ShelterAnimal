using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IExpenseService
    {
        Task<List<Expense>> GetAll();
        Task<Expense> GetById(int id);
        Task Create(Expense model);
        Task Update(Expense model);
        Task Delete(int id);
    }
}
