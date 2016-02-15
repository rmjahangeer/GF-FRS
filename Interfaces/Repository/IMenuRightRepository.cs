﻿using System.Collections.Generic;
using System.Linq;
using FRS.Models.MenuModels;

namespace FRS.Interfaces.Repository
{
    public interface IMenuRightRepository : IBaseRepository<MenuRight, long>
    {
        IQueryable<MenuRight> GetMenuByRole(string roleId);

        IEnumerable<MenuRight> GetByRoleName(string role);
    }
}
