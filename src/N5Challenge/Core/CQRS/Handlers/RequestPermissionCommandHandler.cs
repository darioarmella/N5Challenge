using Core.CQRS.Commands;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using MediatR;

namespace Core.CQRS.Handlers
{
	public class RequestPermissionCommandHandler : IRequestHandler<RequestPermissionCommand, PermissionDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IElasticSearchService _elasticsearchService;

		public RequestPermissionCommandHandler(
			IUnitOfWork unitOfWork,
			IElasticSearchService elasticsearchService)
		{
			_unitOfWork = unitOfWork;
			_elasticsearchService = elasticsearchService;
		}

		public async Task<PermissionDto> Handle(RequestPermissionCommand request, CancellationToken cancellationToken)
		{
			var permission = new Permission
			{
				EmployeeForename = request.PermissionDto.EmployeeForename,
				EmployeeSurname = request.PermissionDto.EmployeeSurname,
				PermissionType = request.PermissionDto.PermissionType,
				PermissionDate = request.PermissionDto.PermissionDate
			};

			var repo = _unitOfWork.GetRepository<Permission>();
			await repo.AddAsync(permission);
			await _unitOfWork.SaveChangesAsync();

			// Indexar en Elasticsearch
			await _elasticsearchService.IndexPermissionAsync(permission);

			return new PermissionDto
			{
				Id = permission.Id,
				EmployeeForename = permission.EmployeeForename,
				EmployeeSurname = permission.EmployeeSurname,
				PermissionType = permission.PermissionType,
				PermissionDate = permission.PermissionDate
			};
		}
	}
}
