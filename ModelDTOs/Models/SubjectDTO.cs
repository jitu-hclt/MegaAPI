using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDTOs.Models
{
	public class SubjectDTO
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int SubId { get; set; }

		[Required]
		[MaxLength(30)]
		public string Name { get; set; }

		public virtual ICollection<GradeDTO> Grades { get; set; }
	}
}

