using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IStaffService
    {
        Task<List<Staff>> GetAll();
        Task<Staff> GetById(int id);
        Task Create(Staff model);
        Task Update(Staff model);
        Task Delete(int id);
    }
}
