using System;
using System.Net.Http.Headers;
using AutoMapper;
using BusinessEntities.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Design.Internal;
using ModelDTOs.Models;

namespace BLLayer.MappingConfigurations
{
	public class UserProfile:Profile
	{
		public UserProfile()
		{
			CreateMap<UserDTO, User>().ReverseMap();            
        }
	}
}

