using System;
using System.Collections.Generic;

namespace pobrify.DAO
{
    interface IDAO<T> where T : class
    {
        List<T> Index();
        T GetByID(int id);
        void Add(T entity);
        void AddMany(params T[] entities);
        void Update(T entity, int id);
        void Delete();
        void DeleteById(int id);
        void DeleteAll();
        void DeleteMany(params T[] entities);
    }
}
