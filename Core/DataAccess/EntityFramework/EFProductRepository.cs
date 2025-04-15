using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
	public class EFProductRepository<TEntity, TContext> : IProductRepository<TEntity>
	  where TEntity : class, IEntity, new() //TEntity class olmalı , IEntity türünde olmalı , newlenebilmeli.

	   where TContext : DbContext, new()  //TContext DbContext türünde olmalı , newlenebilmeli 
	{
		private TContext _context;
		public EFProductRepository(TContext context)
		{
			_context = context;
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
			await _context.Set<TEntity>().AddAsync(entity);
			bool isAdded = _context.Entry(entity).State == EntityState.Added;
			if (isAdded)
			{
				await _context.SaveChangesAsync();
				return entity;
			}
			else
			{
				return null;
			}
		}

		public async Task<bool> DeleteAsync(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
			bool isDeleted = _context.Entry(entity).State == EntityState.Deleted;
			if (isDeleted)
			{
				await _context.SaveChangesAsync();
			}
			return isDeleted;
		}

		public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
		{
			return filter == null ?
				   await _context.Set<TEntity>().ToListAsync() :
				   await _context.Set<TEntity>().Where(filter).ToListAsync();
		}


		public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> filter )
		{
				return await _context.Set<TEntity>().SingleOrDefaultAsync(filter);

		}

		public async Task<bool> UpdateAsync(TEntity entity)
		{
			_context.Set<TEntity>().Update(entity);
			var isUpdated = _context.Entry(entity).State == EntityState.Modified;
			if (isUpdated)
			{
				await _context.SaveChangesAsync();
			}
			return isUpdated;
		}

	}
}
