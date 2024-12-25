using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IDonationService
    {
        Task<List<Donation>> GetAll();
        Task<Donation> GetById(int id);
        Task Create(Donation model);
        Task Update(Donation model);
        Task Delete(int id);
    }
}
