using Core.DTOs;
using MediatR;

namespace Core.CQRS.Commands
{
	public record ModifyPermissionCommand(UpdatePermissionDto PermissionDto)
	: IRequest<PermissionDto>;
}
