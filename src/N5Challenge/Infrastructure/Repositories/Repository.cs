using Core.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly AppDbContext _context;
		private DbSet<T> _dbSet;

		public Repository(AppDbContext context) 
		{
			_context = (AppDbContext)context;
			_dbSet = ((DbContext)context).Set<T>();
		}

		public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

		public void Delete(T entity)
		{
			throw new NotImplementedException();
		}

		public async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();

		public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

		public void Update(T entity)
		{
			_dbSet.Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}
	}
}
