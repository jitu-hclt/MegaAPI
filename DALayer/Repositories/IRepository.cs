using System;
using Microsoft.EntityFrameworkCore;

namespace DALayer.Repositories
{
	public interface IRepository<TEntity>
	{
        public IEnumerable<TEntity> GetAll();

        public TEntity GetById(int id);

        public TEntity Add(TEntity entity);

        public TEntity Update(TEntity entity);

        public TEntity Delete(TEntity entity);

        public bool Exists(int id);
    }
}

