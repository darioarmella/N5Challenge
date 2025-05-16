namespace Core.Interfaces.Repositories
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync();
		IRepository<T> GetRepository<T>() where T : class;
	}
}
