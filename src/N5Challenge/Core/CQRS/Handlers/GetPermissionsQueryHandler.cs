using AutoMapper;
using Core.CQRS.Commands;
using Core.DTOs;
using Core.Interfaces.Services;
using MediatR;

namespace Core.CQRS.Handlers
{
	public class GetPermissionsQueryHandler
	: IRequestHandler<GetPermissionsQuery, IEnumerable<PermissionDto>>
	{
		private readonly IElasticSearchService _elasticsearchService;
		private readonly IMapper _mapper;

		public GetPermissionsQueryHandler(
			IElasticSearchService elasticsearchService,
			IMapper mapper)
		{
			_elasticsearchService = elasticsearchService;
			_mapper = mapper;
		}

		public async Task<IEnumerable<PermissionDto>> Handle(
			GetPermissionsQuery request,
			CancellationToken cancellationToken)
		{
			var permissions = await _elasticsearchService.GetAllPermissionsAsync();

			return _mapper.Map<IEnumerable<PermissionDto>>(permissions);
		}
	}
}
