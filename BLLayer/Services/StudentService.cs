using System;
using System.Collections.Generic;
using AutoMapper;
using BusinessEntities.Models;
using DALayer.Repositories;
using DALayer.RepositoryUOW;
using ModelDTOs.Models;

namespace BLLayer.Services
{
	public class StudentService: IStudentService
	{
		private IStudentRepository _studentRepo;
		private IUnitOfWork _uow;
		private IMapper _mapper;
		public StudentService(IUnitOfWork uow, IMapper mapper )
		{
			_uow = uow;
			_studentRepo = uow.StudentRepository;
			_mapper = mapper;
		}

		public IEnumerable<StudentDTO> GetStudents()
		{			
			return _mapper.Map<IEnumerable<StudentDTO>>(_studentRepo.GetAll());
		}

		public StudentDTO GetStudentById(int id)
		{
			return _mapper.Map<StudentDTO>(_studentRepo.GetById(id));
		}

        public StudentDTO CreateStudent(StudentDTO student)
        {
            return _mapper.Map<StudentDTO>(_studentRepo.Add(_mapper.Map<Student>(student)));
        }

        public StudentDTO UpdateStudent(StudentDTO student)
        {

			return _mapper.Map<StudentDTO>(_studentRepo.Update(_mapper.Map<Student>(student)));
            
            
        }

        public StudentDTO DeleteStudent(StudentDTO student)
        {
            return _mapper.Map<StudentDTO>(_studentRepo.Delete(_mapper.Map<Student>(student)));
        }

		public bool CheckIfStudentExists(int id)
		{
			return _studentRepo.Exists(id);
		}

		public int SaveChanges()
		{
			return _uow.SaveChangesAsync().Result;
		}
    }
}

