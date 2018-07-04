using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Domain.Interfaces;

namespace Infra.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(DbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }
       
        public virtual TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objreturn = DbSet.Add(obj);
            return objreturn;
        }

        public TEntity Atualizar(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public virtual void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
