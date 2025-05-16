using Core.DTOs;
using MediatR;

namespace Core.CQRS.Commands
{
	//public record RequestPermissionCommand(
	//string EmployeeForename,
	//string EmployeeSurname,
	//int PermissionType,
	//DateTime PermissionDate) : IRequest<int>;

	public record RequestPermissionCommand(CreatePermissionDto PermissionDto)
	: IRequest<PermissionDto>;
}
