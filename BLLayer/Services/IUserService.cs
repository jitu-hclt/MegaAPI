using System;
using BusinessEntities.Models;
using ModelDTOs.Models;

namespace BLLayer.Services
{
	public interface IUserService
	{
		public UserDTO Validate(string Email, string Password);
	}
}

