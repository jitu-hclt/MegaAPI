using System;
using DALayer.Repositories;

namespace DALayer.RepositoryUOW
{
	public interface IUnitOfWork
	{
		public IStudentRepository StudentRepository { get;}
		public IGradeRepository GradeRepository { get;}
		public ISubjectRepository SubjectRepository { get;}
		public IUserRepository UserRepository { get;}

        public Task<int> SaveChangesAsync();
    }
}

