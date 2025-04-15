using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
	public interface IProductRepository<T> where T : class,IEntity, new()
	{
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
		Task<T> GetByIdAsync(Expression<Func<T, bool>> filter);
		Task<T> AddAsync(T entity);
		Task<bool> UpdateAsync(T entity);
		Task<bool> DeleteAsync(T entity);
	}
}
