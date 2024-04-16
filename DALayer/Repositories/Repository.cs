using System;
using BusinessEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace DALayer.Repositories
{
	public class Repository<TEntity>:IRepository<TEntity>  where TEntity:class
	{
		private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSetEntity; 

		public Repository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
            _dbSetEntity = dbContext.Set<TEntity>();

        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSetEntity.AsEnumerable<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _dbSetEntity.Find(id);
        }

        public TEntity Add(TEntity student)
        {
            _dbSetEntity.Add(student);
            return student;
        }

        public TEntity Update(TEntity student)
        {
            _dbSetEntity.Update(student);

            return student;

        }

        public TEntity Delete(TEntity student)
        {
            _dbSetEntity.Remove(student);
            return student;
        }

        public bool Exists(int id)
        {
            var entity = _dbSetEntity.Find(id);
            return entity==null?false:true;
        }

    }
}

