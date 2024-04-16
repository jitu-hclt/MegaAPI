using System;
using BusinessEntities.Models;
using DALayer;
using Microsoft.EntityFrameworkCore;

namespace DALayer.Repositories
{
	public class SubjectRepository:Repository<Subject>, ISubjectRepository
	{
        private readonly ApplicationDbContext _dbContext;
        

        public SubjectRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

