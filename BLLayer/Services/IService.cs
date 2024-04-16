using System;
namespace BLLayer.Services
{
	public interface IService
	{
		public IStudentService StudentService { get;}
		public IUserService UserService { get;}
		public IGradeService GradeService { get;}

	}
}

