using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAuditLogService
    {
        Task<List<AuditLog>> GetAll();
        Task<AuditLog> GetById(int id);
        Task Create(AuditLog model);
        Task Update(AuditLog model);
        Task Delete(int id);
    }
}
