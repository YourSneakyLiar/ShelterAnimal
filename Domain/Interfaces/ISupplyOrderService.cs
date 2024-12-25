using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ISupplyOrderService
    {
        Task<List<SupplyOrder>> GetAll();
        Task<SupplyOrder> GetById(int id);
        Task Create(SupplyOrder model);
        Task Update(SupplyOrder model);
        Task Delete(int id);
    }
}
