using Core.DTOs;
using MediatR;

namespace Core.CQRS.Commands
{
	public record GetPermissionsQuery : IRequest<IEnumerable<PermissionDto>>;
}
