using System;
using System.ComponentModel.DataAnnotations;

namespace ModelDTOs.Models
{
	public class TeacherDTO
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}

