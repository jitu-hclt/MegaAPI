using System;
using AutoMapper;
using DALayer.RepositoryUOW;

namespace BLLayer.Services
{
	public class Service:IService
	{
        private IUnitOfWork _uow;
        private IMapper _mapper;

        public Service(IUnitOfWork uow, IMapper mapper)
        {
            StudentService = new StudentService(uow, mapper);
            UserService = new UserService(uow, mapper);
            GradeService = new GradeService(uow, mapper);
        }

        public IStudentService StudentService { get; private set; }
        public IUserService UserService { get; private set; }
        public IGradeService GradeService { get; private set; }
    }
}

