﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;

namespace ScadaWeb.IRepository
{
    public interface IOrganizeRepository : IBaseRepository<OrganizeModel>
    {
        IEnumerable<OrganizeModel> GetOrganizeList();
    }
}
