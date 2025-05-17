using AutoMapper;
using Core.CQRS.Commands;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using MediatR;

namespace Core.CQRS.Handlers
{
	public class ModifyPermissionCommandHandler
	: IRequestHandler<ModifyPermissionCommand, PermissionDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IElasticSearchService _elasticsearchService;

		public ModifyPermissionCommandHandler(
			IUnitOfWork unitOfWork,
			IMapper mapper,
			IElasticSearchService elasticsearchService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_elasticsearchService = elasticsearchService;
		}

		public async Task<PermissionDto> Handle(
			ModifyPermissionCommand request,
			CancellationToken cancellationToken)
		{
			var repo = _unitOfWork.GetRepository<Permission>();

			var existingPermission = await repo.GetByIdAsync(request.PermissionDto.Id);
			
			if (existingPermission == null)
			{
				throw new Exception($"Permission with ID {request.PermissionDto.Id} not found");
			}

			existingPermission.PermissionType = request.PermissionDto.PermissionType;
			existingPermission.PermissionDate = request.PermissionDto.PermissionDate;

			repo.Update(existingPermission);
			await _unitOfWork.SaveChangesAsync();

			await _elasticsearchService.UpdatePermissionAsync(existingPermission);

			// 5. Devolver DTO
			return _mapper.Map<PermissionDto>(existingPermission);
		}
	}

}
