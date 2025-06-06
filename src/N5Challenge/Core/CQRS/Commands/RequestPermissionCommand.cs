﻿using Core.DTOs;
using MediatR;

namespace Core.CQRS.Commands
{
	public record RequestPermissionCommand(CreatePermissionDto PermissionDto)
	: IRequest<PermissionDto>;
}
