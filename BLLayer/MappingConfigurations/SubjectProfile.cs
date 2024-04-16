using System;
using AutoMapper;
using BusinessEntities.Models;
using ModelDTOs.Models;

namespace BLLayer.MappingConfigurations
{
	public class SubjectProfile:Profile
	{
		public SubjectProfile()
		{
			CreateMap<SubjectDTO, Subject>().ReverseMap();
            //CreateMap<Subject, SubjectDTO>();
        }
	}
}

