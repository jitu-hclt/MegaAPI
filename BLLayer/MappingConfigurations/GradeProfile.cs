using System;
using System.Net.Http.Headers;
using AutoMapper;
using BusinessEntities.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Design.Internal;
using ModelDTOs.Models;

namespace BLLayer.MappingConfigurations
{
	public class GradeProfile:Profile
	{
		public GradeProfile()
		{
			//CreateMap<GradeDTO, Grade>().ReverseMap();
			CreateMap<Grade, GradeDTO>()
				.ForMember(dest=>dest.GradeName, opt=>opt.MapFrom(src=>src.Name))
				.ForMember(dest=>dest.Id, opt=>opt.MapFrom(src=>src.Id))
				.ReverseMap();
        }
	}
}

