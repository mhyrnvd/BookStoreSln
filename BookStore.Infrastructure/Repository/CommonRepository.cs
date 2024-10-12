using BookStore.Core.RepositoryContracts;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repository
{
    public class CommonRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;
        public CommonRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetById(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }

        public void Remove(T entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}
