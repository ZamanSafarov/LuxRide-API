using LuxRide.Application.Interfaces;
using LuxRide.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly LuxrideDbContext _context;

		public Repository(LuxrideDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
		}

		public async Task Commit()
		{
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, params string[]? includes)
		{
			IQueryable<T> query = _context.Set<T>();

			if (includes is not null)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}
			return await (filter == null ? query.AsNoTracking().ToListAsync() : query.Where(filter).AsNoTracking().ToListAsync());
		}

		public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, params string[]? includes)
		{
			IQueryable<T> query = _context.Set<T>();

			if (includes is not null)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}
			return await (filter == null ? query.AsNoTracking().FirstOrDefaultAsync() : query.AsNoTracking().FirstOrDefaultAsync(filter));
		}

		public async Task HardDeleteAsync(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public async Task Update(T entity)
		{
			_context.Set<T>().Update(entity);
		}

	}
}
