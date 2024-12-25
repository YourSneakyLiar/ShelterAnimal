using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IEventAttendanceService
    {
        Task<List<EventAttendance>> GetAll();
        Task<EventAttendance> GetById(int id);
        Task Create(EventAttendance model);
        Task Update(EventAttendance model);
        Task Delete(int id);
    }
}
