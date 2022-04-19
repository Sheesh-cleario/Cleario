using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private CleaningContext _context { get; set; }
		public GenericRepository(CleaningContext context)
		{
			_context = context;
		}

		public async Task<int> CountAsync(ISpecification<T> spec)
		{
			return await ApplySpecification(spec).CountAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _context.Set<T>().FindAsync(id);
			_context.Set<T>().Remove(entity);
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
		{
			return await ApplySpecification(spec).FirstOrDefaultAsync();
		}

		public async Task<IReadOnlyList<T>> ListAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
		{
			return await ApplySpecification(spec).ToListAsync();
		}

		private IQueryable<T> ApplySpecification(ISpecification<T> spec)
		{
			return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
		}

		public async Task<int> CountAllAsync()
		{
			return await _context.Set<T>().CountAsync();
		}

		public async Task AddEntityAsync(T entity)
		{
			var result = await _context.Set<T>().AddAsync(entity);
			_context.SaveChanges();
		}
	}
}
