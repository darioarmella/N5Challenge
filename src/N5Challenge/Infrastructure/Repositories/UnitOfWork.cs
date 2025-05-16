using Core.Interfaces.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;

		public UnitOfWork(AppDbContext context) => _context = context;

		public IRepository<T> GetRepository<T>() where T : class => new Repository<T>(_context);
		public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
	}
}
