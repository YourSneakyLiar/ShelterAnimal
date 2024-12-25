using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AdoptionRepository : RepositoryBase<Adoption>, IAdoptionRepository
    {
        public AdoptionRepository(AnimalShelterContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
