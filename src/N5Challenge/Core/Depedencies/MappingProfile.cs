using AutoMapper;
using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Depedencies
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CreatePermissionDto, Permission>();
			CreateMap<UpdatePermissionDto, Permission>();
			CreateMap<Permission, PermissionDto>();
		}
	}
}
