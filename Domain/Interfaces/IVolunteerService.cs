using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IVolunteerService
    {
        Task<List<Volunteer>> GetAll();
        Task<Volunteer> GetById(int id);
        Task Create(Volunteer model);
        Task Update(Volunteer model);
        Task Delete(int id);
    }
}
