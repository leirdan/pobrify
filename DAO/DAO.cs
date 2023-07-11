//using System;
//using System.Collections.Generic;

//namespace pobrify.DAO
//  TODO: VER COMO IMPLEMENTAR ISSO
//{
//    abstract class DAO<T> : IDAO<T> where T : class
//    {
//        protected PobrifyContext con = new PobrifyContext();
//        public DAO()
//        {
//            var c = new PobrifyContext();
//            if (T != song)
//            {

//            }
//        }

//        public virtual void Add(T entity)
//        {
//            con.[TYPES.Albums].Add(entity);
//            con.SaveChanges();
//        };
//        public abstract void AddMany(params T[] entities);
//        public abstract void Delete();
//        public abstract void DeleteAll();
//        public abstract void DeleteById(int id);
//        public abstract void DeleteMany(params T[] entities);
//        public abstract T GetByID(int id);
//        public abstract List<T> Index();
//        public abstract void Update(T entity, int id);
//    }
//}
