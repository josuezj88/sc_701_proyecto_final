﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DO.Interface
{
    public interface ICRUD<T>
    {
        void Insert(T t);

        void Update(T t);

        void Delete(T t);

        IEnumerable<T> GetAll();

        T GetOneById(int id);

        T GetOneByIdString(string id);

        Task<IEnumerable<T>> GetAllWithAsync();

        Task<T> GetOneByIdWithAsync(int id);
    }
}
