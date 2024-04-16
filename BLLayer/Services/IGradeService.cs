using System;
using BusinessEntities.Models;
using ModelDTOs.Models;

namespace BLLayer.Services
{
	public interface IGradeService
	{
        public IEnumerable<GradeDTO> GetGrades();

        public GradeDTO GetGradeById(int id);

        public GradeDTO CreateGrade(GradeDTO student);

        public GradeDTO UpdateGrade(GradeDTO student);

        public GradeDTO DeleteGrade(GradeDTO student);

        public bool CheckIfGradeExists(int id);

        public int SaveChanges();
    }
}

