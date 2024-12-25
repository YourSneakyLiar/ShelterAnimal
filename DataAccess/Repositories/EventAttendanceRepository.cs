using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EventAttendanceRepository : RepositoryBase<EventAttendance>, IEventAttendanceRepository
    {
        public EventAttendanceRepository(AnimalShelterContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
