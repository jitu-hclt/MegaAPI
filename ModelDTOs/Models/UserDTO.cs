using System;
using System.ComponentModel.DataAnnotations;

namespace ModelDTOs.Models
{
	public class UserDTO
	{
		//[Key]
		//[EmailAddress]
		public string Email { get; set; }

		//[DataType(DataType.Password)]
		public string Password { get; set; }
				
		public int Age { get; set; }
	}
}

