using System;
using BusinessEntities.Models;
using DALayer;
using Microsoft.EntityFrameworkCore;

namespace DALayer.Repositories
{
	public class GradeRepository:Repository<Grade>, IGradeRepository
	{
        private readonly ApplicationDbContext _dbContext;
        

        public GradeRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

