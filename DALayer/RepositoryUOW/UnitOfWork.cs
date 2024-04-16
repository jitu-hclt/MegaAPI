using System;
using DALayer.Repositories;

namespace DALayer.RepositoryUOW
{
	public class UnitOfWork:IUnitOfWork
	{
		private readonly ApplicationDbContext _dbContext;

		public UnitOfWork(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
			StudentRepository = new StudentRepository(_dbContext);
			GradeRepository = new GradeRepository(_dbContext);
			SubjectRepository = new SubjectRepository(_dbContext);
			UserRepository = new UserRepository(_dbContext);
		}

        public IStudentRepository StudentRepository { get; private set; }
        public IGradeRepository GradeRepository { get; private set; }
        public ISubjectRepository SubjectRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}

