using System;
using BusinessEntities.Models;

namespace DALayer.Repositories
{
	public interface IUserRepository:IRepository<User>
	{
        public User ValidateUser(User user);
    }
}

