using System;
using BusinessEntities.Models;
using ModelDTOs.Models;

namespace BLLayer.Services
{
	public interface IStudentService
	{
        public IEnumerable<StudentDTO> GetStudents();

        public StudentDTO GetStudentById(int id);

        public StudentDTO CreateStudent(StudentDTO student);

        public StudentDTO UpdateStudent(StudentDTO student);

        public StudentDTO DeleteStudent(StudentDTO student);

        public bool CheckIfStudentExists(int id);

        public int SaveChanges();
    }
}

