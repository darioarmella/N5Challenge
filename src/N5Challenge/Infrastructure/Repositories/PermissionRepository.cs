using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
	public class PermissionRepository : Repository<Permission>, IPermissionRepository
	{
		private readonly AppDbContext _context;

		public PermissionRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
