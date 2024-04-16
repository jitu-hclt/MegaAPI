using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities.Models
{
	public class Grade
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(20)]
		public string Name { get; set; }

		public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}

