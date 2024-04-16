using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelDTOs.Models
{
	public class GradeDTO
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(20)]
		public string GradeName { get; set; }

		public virtual ICollection<StudentDTO> Students { get; set; }

        public virtual ICollection<SubjectDTO> Subjects { get; set; }
    }
}

