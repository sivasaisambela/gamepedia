﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PlayStationStore.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

    }
}
