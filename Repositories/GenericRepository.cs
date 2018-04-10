using Microsoft.EntityFrameworkCore;
using SMSAPI.Tree.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSAPI.Tree.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        protected DbContext _entities;
        protected readonly DbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> Get()
        {
            return this._dbset;
        }

        public virtual T Get(string id)
        {
            return this._dbset.Find(id);
        }

        public virtual void Create(T data)
        {
            this._dbset.Add(data);
            this._entities.SaveChanges();
        }

        public virtual void Update(T data)
        {
            this._entities.Entry(data).State = EntityState.Modified;
            this._entities.SaveChanges();
        }

        public virtual void Delete(string id)
        {
            T entity = this._dbset.Find(id);
            this._entities.Entry(entity).State = EntityState.Deleted;
            this._entities.SaveChanges();
        }

        public bool Exists(string id)
        {
            return this._dbset.Any(x => x.Id == id);
        }
    }
}
