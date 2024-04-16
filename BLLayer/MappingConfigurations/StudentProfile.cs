using System;
using AutoMapper;
using BusinessEntities.Models;
using ModelDTOs.Models;

namespace BLLayer.MappingConfigurations
{
	public class StudentProfile:Profile
	{
		public StudentProfile()
		{
			CreateMap<StudentDTO, Student>().ReverseMap();
            //CreateMap<Student, StudentDTO>();
        }
	}
}

