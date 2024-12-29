﻿using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Repositories
{
    public interface IPermissionRepository : IGenericRepository<Permission, int>
    {
    }
}
