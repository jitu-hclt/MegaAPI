using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessEntities.Models
{
	public class Student
	{
		
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public int RollNo { get; set; }

		public string ContactNo { get; set; }

		[DataType(DataType.Date)]        
        public DateTime DOB { get; set; }

		[Required]
        //[ForeignKey("Grade")]
        public int GradeId { get; set; }

		//Navigation key
		[ForeignKey("GradeId")]
		public virtual Grade Grade { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}


//Relationships are vector - directional
//Student -> Grade , Many - > One
//Grade -> Studnet, 1 Grade -> Many, one to many

//One to many or many to one

//Student -> Aaadhar Details : One to One
//Addhar -> Student-> One to one
//One to one

//student -> subject = One to many
//subject to student  = One to many
//Many to many relationship

