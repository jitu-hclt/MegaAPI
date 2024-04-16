using System;
using BusinessEntities.Models;
using DALayer;
using Microsoft.EntityFrameworkCore;

namespace DALayer.Repositories
{
	public class StudentRepository:Repository<Student>, IStudentRepository
	{
        private readonly ApplicationDbContext _dbContext;
        

        public StudentRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

