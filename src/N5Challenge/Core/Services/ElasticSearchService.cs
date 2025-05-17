using Core.Entities;
using Core.Interfaces.Services;
using Nest;

namespace Core.Services
{
	public class ElasticSearchService : IElasticSearchService
	{
		private readonly ElasticClient _client;
		private const string IndexName = "permissions";

		public ElasticSearchService(string uri)
		{
			var settings = new ConnectionSettings(new Uri(uri))
				.DefaultIndex(IndexName);
			_client = new ElasticClient(settings);
		}

		public async Task IndexPermissionAsync(Permission permission)
		{
			await _client.IndexDocumentAsync(permission);
		}

		public async Task UpdatePermissionAsync(Permission permission)
		{
			var response = await _client.UpdateAsync<Permission>(
				permission.Id,
				u => u.Doc(permission).Index(IndexName));

			if (!response.IsValid) throw new Exception("Error al actualizar");
		}

		public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
		{
			var searchResponse = await _client.SearchAsync<Permission>(s => s
				.Index(IndexName)
				.MatchAll()
				.Size(1000));

			return searchResponse.Documents;
		}
	}
}
