using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities.Models
{
	public class Teacher
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}

