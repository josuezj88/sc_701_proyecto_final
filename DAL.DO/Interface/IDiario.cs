﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DO.Interface
{
    public interface IDiario<T>
    {
        Task<IEnumerable<T>> GetAllWithAsyncById(int id);
    }
}
