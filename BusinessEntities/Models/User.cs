using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities.Models
{
	public class User
	{
		[Key]
		[EmailAddress]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }
				
		public int Age { get; set; }
	}
}

