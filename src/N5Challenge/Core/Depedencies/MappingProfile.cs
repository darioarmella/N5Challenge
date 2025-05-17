using AutoMapper;
using Core.DTOs;
using Core.Entities;

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
