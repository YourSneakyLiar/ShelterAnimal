using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserRoleService
    {
        Task<List<UserRole>> GetAll();
        Task<UserRole> GetById(int id);
        Task Create(UserRole model);
        Task Update(UserRole model);
        Task Delete(int id);
    }
}
