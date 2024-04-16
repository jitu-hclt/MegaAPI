using System;
using BusinessEntities.Models;
using DALayer;
using Microsoft.EntityFrameworkCore;

namespace DALayer
{
	public static class SeedDatabase
	{
		public static void Seed(ApplicationDbContext dbContext)
		{

            dbContext.Database.Migrate();            

            var studentList = dbContext.Students;

			if (studentList.Count<Student>() == 0)
			{
				dbContext.Students.AddRange(
                    new Student()
                    {
                        Name = "Kumar",
                        RollNo = 1001,
                        GradeId = 3,
                        ContactNo = "6756756757",
                        DOB = new DateTime(2003, 5, 19)
                    },
                    new Student()
                    {
                        Name = "Rajesh",
                        RollNo = 1002,
                        GradeId = 4,
                        ContactNo = "6756756757",
                        DOB = new DateTime(2003, 7, 21)
                    },
                    new Student()
                    {
                        Name = "Vanitha",
                        RollNo = 1003,
                        GradeId = 2,
                        ContactNo = "6756756757",
                        DOB = new DateTime(2005, 6, 19)
                    },
                    new Student()
                    {
                        Name = "Ritika",
                        RollNo = 1004,
                        GradeId = 5,
                        ContactNo = "6756756757",
                        DOB = new DateTime(2001, 12, 11)
                    }

                );
                dbContext.SaveChanges();

            }
		}

	}
}

