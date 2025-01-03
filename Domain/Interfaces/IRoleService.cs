﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAll();
        Task<Role> GetById(int id);
        Task Create(Role model);
        Task Update(Role model);
        Task Delete(int id);
    }
}
