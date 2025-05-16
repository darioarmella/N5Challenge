using Core.Entities;
using Core.Interfaces.Services;
using Nest;

namespace Core.Services
{
	public class ElasticSearchService : IElasticSearchService
	{
		private readonly ElasticClient _client;

		public ElasticSearchService(string uri)
		{
			var settings = new ConnectionSettings(new Uri(uri))
				.DefaultIndex("permissions");
			_client = new ElasticClient(settings);
		}

		public async Task IndexPermissionAsync(Permission permission)
		{
			await _client.IndexDocumentAsync(permission);
		}
	}
}
