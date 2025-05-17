using Core.Entities;

namespace Core.Interfaces.Services
{
	public interface IElasticSearchService
	{
		Task IndexPermissionAsync(Permission permission);
		Task UpdatePermissionAsync(Permission permission);
		Task<IEnumerable<Permission>> GetAllPermissionsAsync();
	}
}
