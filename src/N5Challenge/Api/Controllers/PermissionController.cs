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
		private readonly ILogger<PermissionController> _logger;

		public PermissionController(IMediator mediator, ILogger<PermissionController> logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		[HttpPost]
		public async Task<IActionResult> RequestPermission([FromBody] CreatePermissionDto dto)
		{
			var command = new RequestPermissionCommand(dto);
			var result = await _mediator.Send(command);

			_logger.LogInformation("Fin de ejecucion del servicio PermissionController.RequestPermission {@dto}", dto);

			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> ModifyPermission([FromBody] UpdatePermissionDto dto)
		{
			var command = new ModifyPermissionCommand(dto);
			var result = await _mediator.Send(command);

			_logger.LogInformation("Fin de ejecucion del servicio PermissionController.ModifyPermission {@dto}", dto);

			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetPermissions()
		{
			var query = new GetPermissionsQuery();
			var result = await _mediator.Send(query);

			_logger.LogInformation("Fin de ejecucion del servicio PermissionController.GetPermissions");

			return Ok(result);
		}
	}
}
