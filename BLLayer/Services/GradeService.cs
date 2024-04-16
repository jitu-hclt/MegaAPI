using System;
using System.Collections.Generic;
using AutoMapper;
using BusinessEntities.Models;
using DALayer.Repositories;
using DALayer.RepositoryUOW;
using ModelDTOs.Models;

namespace BLLayer.Services
{
	public class GradeService: IGradeService
	{
		private IGradeRepository _gradeRepo;
		private IUnitOfWork _uow;
		private IMapper _mapper;
		public GradeService(IUnitOfWork uow, IMapper mapper )
		{
			_uow = uow;
			_gradeRepo = uow.GradeRepository;
			_mapper = mapper;
		}

		public IEnumerable<GradeDTO> GetGrades()
		{


			return _mapper.Map<IEnumerable<Grade>, IEnumerable<GradeDTO>>(_gradeRepo.GetAll());
		}

		public GradeDTO GetGradeById(int id)
		{
			return _mapper.Map<GradeDTO>(_gradeRepo.GetById(id));
		}

        public GradeDTO CreateGrade(GradeDTO grade)
        {
            return _mapper.Map<GradeDTO>(_gradeRepo.Add(_mapper.Map<Grade>(grade)));
        }

        public GradeDTO UpdateGrade(GradeDTO grade)
        {

			return _mapper.Map<GradeDTO>(_gradeRepo.Update(_mapper.Map<Grade>(grade)));
            
            
        }

        public GradeDTO DeleteGrade(GradeDTO grade)
        {
            return _mapper.Map<GradeDTO>(_gradeRepo.Delete(_mapper.Map<Grade>(grade)));
        }

		public bool CheckIfGradeExists(int id)
		{
			return _gradeRepo.Exists(id);
		}

		public int SaveChanges()
		{
			return _uow.SaveChangesAsync().Result;
		}
    }
}

