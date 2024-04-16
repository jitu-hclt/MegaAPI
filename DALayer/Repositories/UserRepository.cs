using System;
using BusinessEntities.Models;
using DALayer;
using Microsoft.EntityFrameworkCore;

namespace DALayer.Repositories
{
	public class UserRepository:Repository<User>, IUserRepository
	{
        private readonly ApplicationDbContext _dbContext;
        

        public UserRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public User ValidateUser(User user)
        {
            return _dbContext.Users.FirstOrDefault(u=>u.Email==user.Email && u.Password==user.Password);
        }
    }
}

