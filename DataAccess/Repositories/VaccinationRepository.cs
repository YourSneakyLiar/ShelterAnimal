﻿using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class VaccinationRepository : RepositoryBase<Vaccination>, IVaccinationRepository
    {
        public VaccinationRepository(AnimalShelterContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
