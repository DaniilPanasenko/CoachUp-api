using System;
using System.Collections.Generic;
using System.Linq;
using CoachUp.DAL.Context;
using CoachUp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoachUp.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected CoachUpContext db;

        public Repository(CoachUpContext context)
        {
            this.db = context;
        }

        public void Create(T item)
        {
            db.Set<T>().Add(item);
        }

        public void Delete(int id)
        {
            T entity = db.Set<T>().Find(id);
            if (entity != null)
                db.Set<T>().Remove(entity);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

    }
}
