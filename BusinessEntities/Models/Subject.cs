using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessEntities.Models
{
	public class Subject
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int SubId { get; set; }

		[Required]
		[MaxLength(30)]
		public string Name { get; set; }

		public virtual ICollection<Grade> Grades { get; set; }

		public virtual ICollection<Student> Students { get; set; }
	}
}

