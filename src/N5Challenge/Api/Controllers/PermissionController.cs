using Core.CQRS.Commands;
using Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PermissionController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PermissionController(IMediator mediator) => _mediator = mediator;

		[HttpPost]
		public async Task<IActionResult> RequestPermission([FromBody] CreatePermissionDto dto)
		{
			var command = new RequestPermissionCommand(dto);
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> ModifyPermission([FromBody] UpdatePermissionDto dto)
		{
			var command = new ModifyPermissionCommand(dto);
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetPermissions()
		{
			var query = new GetPermissionsQuery();
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
